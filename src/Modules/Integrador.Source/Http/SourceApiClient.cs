using Integrador.Common.Logging;
using Integrador.Common.Settings;
using Integrador.Source.Auth;
using Integrador.Source.Contracts;
using System.Net.Http.Json;
using System.Text.Json;

namespace Integrador.Source.Http;

internal sealed class SourceApiClient(HttpClient http, ISettingsService settings, SourceTokenProvider tokenProvider, IIntegrationLogger logger) : ISourceApiClient
{
    private const string Source = nameof(SourceApiClient);

    public async Task<T?> GetAsync<T>(string path, IDictionary<string, string?>? query = null, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Get, BuildUrl(path, query));
        return await SendAsync<T>(request, null, ct);
    }

    public async Task<TResponse?> PostAsync<TPayload, TResponse>(string path, TPayload payload, CancellationToken ct = default)
    {
        using var request = new HttpRequestMessage(HttpMethod.Post, BuildUrl(path))
        {
            Content = JsonContent.Create(payload, options: SourceJson.Options)
        };
        return await SendAsync<TResponse>(request, JsonSerializer.Serialize(payload, SourceJson.Options), ct);
    }

    public async Task<List<TItem>> GetAllPagesAsync<TResponse, TItem>(
        string path,
        Func<TResponse, List<TItem>?> itemsSelector,
        IDictionary<string, string?>? query = null,
        int limit = 50,
        CancellationToken ct = default)
        where TResponse : SourcePagedResponse
    {
        List<TItem> all = [];
        Dictionary<string, string?> q = query != null ? new(query) : [];
        q["limit"] = limit.ToString();

        string? nextToken = null;
        int page = 0;

        do
        {
            ct.ThrowIfCancellationRequested();

            if (!string.IsNullOrWhiteSpace(nextToken))
                q["next_token"] = nextToken;

            var response = await GetAsync<TResponse>(path, q, ct)
                ?? throw new InvalidOperationException($"Resposta vazia da API de origem em {path} (página {page + 1}).");

            if (response.Error == true)
                throw new InvalidOperationException($"A API de origem devolveu erro em {path}: {response.Message}");

            all.AddRange(itemsSelector(response) ?? []);
            nextToken = response.NextToken;

            if (++page > 10_000)
                throw new InvalidOperationException($"Paginação em {path} excedeu o limite de segurança.");

        } while (!string.IsNullOrWhiteSpace(nextToken));

        return all;
    }

    public async Task TestConnectionAsync(CancellationToken ct = default)
    {
        tokenProvider.Invalidate();
        await tokenProvider.GetTokenAsync(ct);
    }

    private async Task<T?> SendAsync<T>(HttpRequestMessage request, string? requestBody, CancellationToken ct)
    {
        using var response = await http.SendAsync(request, ct);
        string body = await response.Content.ReadAsStringAsync(ct);

        if (!response.IsSuccessStatusCode)
        {
            await logger.WriteAsync(LogLevel.ERROR, Source,
                $"Erro na API de origem {request.Method} {request.RequestUri?.PathAndQuery} ({(int)response.StatusCode})",
                body, requestBody);

            throw new HttpRequestException($"Erro na API de origem ({(int)response.StatusCode}) em {request.RequestUri?.AbsolutePath}: {body}", null, response.StatusCode);
        }

        return JsonSerializer.Deserialize<T>(body, SourceJson.Options);
    }

    private string BuildUrl(string path, IDictionary<string, string?>? query = null)
    {
        string url = $"{settings.Get().SourceUrl.TrimEnd('/')}/{path.TrimStart('/')}";

        if (query == null || query.Count == 0)
            return url;

        string qs = string.Join("&", query
            .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
            .Select(kv => $"{Uri.EscapeDataString(kv.Key)}={Uri.EscapeDataString(kv.Value!)}"));

        return string.IsNullOrEmpty(qs) ? url : $"{url}?{qs}";
    }
}
