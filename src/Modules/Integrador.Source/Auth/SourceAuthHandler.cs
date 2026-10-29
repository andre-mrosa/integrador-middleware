using Integrador.Common.Logging;
using Integrador.Common.Settings;
using System.Net;
using System.Net.Http.Headers;

namespace Integrador.Source.Auth;

/// <summary>
/// Acrescenta x-api-key e bearer a todos os pedidos. Em 401 renova o token e repete uma vez.
/// </summary>
internal sealed class SourceAuthHandler(SourceTokenProvider tokenProvider, ISettingsService settings, IIntegrationLogger logger) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        // Conteúdo guardado para poder repetir o pedido (HttpContent só pode ser enviado uma vez)
        byte[]? content = request.Content != null ? await request.Content.ReadAsByteArrayAsync(ct) : null;
        var contentHeaders = request.Content?.Headers.ToList();

        await AuthorizeAsync(request, ct);
        var response = await base.SendAsync(request, ct);

        if (response.StatusCode != HttpStatusCode.Unauthorized)
            return response;

        await logger.WarningAsync(nameof(SourceAuthHandler), $"401 em {request.Method} {request.RequestUri?.AbsolutePath}. A renovar token.");
        response.Dispose();
        tokenProvider.Invalidate();

        using var retry = new HttpRequestMessage(request.Method, request.RequestUri);
        if (content != null)
        {
            retry.Content = new ByteArrayContent(content);
            foreach (var h in contentHeaders!)
                retry.Content.Headers.TryAddWithoutValidation(h.Key, h.Value);
        }

        await AuthorizeAsync(retry, ct);
        return await base.SendAsync(retry, ct);
    }

    private async Task AuthorizeAsync(HttpRequestMessage request, CancellationToken ct)
    {
        request.Headers.Remove("x-api-key");
        request.Headers.Add("x-api-key", settings.Get().SourceApiKey);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", await tokenProvider.GetTokenAsync(ct));
    }
}
