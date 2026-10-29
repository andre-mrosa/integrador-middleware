using Integrador.Common.Logging;
using Integrador.Common.Settings;
using Integrador.Source.Contracts;
using Integrador.Source.Http;
using System.Net.Http.Json;

namespace Integrador.Source.Auth;

/// <summary>
/// Gere o bearer token da API de origem (POST /login, válido 12h). Thread-safe.
/// Invalida o token quando as configurações mudam.
/// </summary>
// TODO: exemplo de autenticação por login + bearer. Adaptar (ou remover) conforme a API real
internal sealed class SourceTokenProvider
{
    public const string HttpClientName = "SourceAuth";
    private const string Source = nameof(SourceTokenProvider);

    // Margem de segurança antes das 12h
    private static readonly TimeSpan _tokenLifetime = TimeSpan.FromHours(11.5);

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ISettingsService _settings;
    private readonly IIntegrationLogger _logger;
    private readonly SemaphoreSlim _lock = new(1, 1);

    private string? _token;
    private DateTime _expiresAt = DateTime.MinValue;

    public SourceTokenProvider(IHttpClientFactory httpClientFactory, ISettingsService settings, IIntegrationLogger logger)
    {
        _httpClientFactory = httpClientFactory;
        _settings = settings;
        _logger = logger;

        _settings.Changed += (_, _) => Invalidate();
    }

    public void Invalidate()
    {
        _token = null;
        _expiresAt = DateTime.MinValue;
    }

    public async Task<string> GetTokenAsync(CancellationToken ct = default)
    {
        if (IsValid) return _token!;

        await _lock.WaitAsync(ct);
        try
        {
            // Outro pedido pode ter renovado enquanto esperávamos
            if (IsValid) return _token!;

            _token = await LoginAsync(ct);
            _expiresAt = DateTime.Now.Add(_tokenLifetime);

            await _logger.InfoAsync(Source, $"Novo token da origem obtido. Válido até {_expiresAt:dd/MM/yyyy HH:mm}.");
            return _token;
        }
        finally
        {
            _lock.Release();
        }
    }

    private bool IsValid => !string.IsNullOrWhiteSpace(_token) && DateTime.Now < _expiresAt;

    private async Task<string> LoginAsync(CancellationToken ct)
    {
        var s = _settings.Get();

        if (string.IsNullOrWhiteSpace(s.SourceApiKey) || string.IsNullOrWhiteSpace(s.SourceUser) || string.IsNullOrWhiteSpace(s.SourcePassword))
            throw new InvalidOperationException("Credenciais da origem incompletas. Verifique as configurações.");

        using var request = new HttpRequestMessage(HttpMethod.Post, $"{s.SourceUrl.TrimEnd('/')}/login")
        {
            Content = JsonContent.Create(new LoginRequest(s.SourceUser, s.SourcePassword), options: SourceJson.Options)
        };
        request.Headers.Add("x-api-key", s.SourceApiKey);

        using var response = await _httpClientFactory.CreateClient(HttpClientName).SendAsync(request, ct);
        string body = await response.Content.ReadAsStringAsync(ct);

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"Erro na autenticação na origem ({(int)response.StatusCode}): {body}", null, response.StatusCode);

        var login = System.Text.Json.JsonSerializer.Deserialize<LoginResponse>(body, SourceJson.Options);

        if (login?.Error == true || string.IsNullOrWhiteSpace(login?.Token))
            throw new InvalidOperationException($"A autenticação na origem não devolveu token. {login?.Message}");

        return login.Token;
    }

    private sealed record LoginRequest(string Email, string Password);

    private sealed class LoginResponse : SourceResponse
    {
        public string? Token { get; set; }
        public string? AuthorizationCode { get; set; }
    }
}
