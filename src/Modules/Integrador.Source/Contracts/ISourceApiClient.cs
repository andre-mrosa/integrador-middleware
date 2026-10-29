namespace Integrador.Source.Contracts;

/// <summary>
/// Acesso à API de origem. Autenticação (x-api-key + bearer 12h) e renovação de token são tratadas internamente.
/// </summary>
// TODO: exemplo de adapter (API REST com paginação por next_token). Renomear o módulo para o sistema real (ex: Integrador.Crm) e adaptar
public interface ISourceApiClient
{
    Task<T?> GetAsync<T>(string path, IDictionary<string, string?>? query = null, CancellationToken ct = default);

    Task<TResponse?> PostAsync<TPayload, TResponse>(string path, TPayload payload, CancellationToken ct = default);

    /// <summary>
    /// Percorre todas as páginas de um endpoint paginado por next_token.
    /// </summary>
    Task<List<TItem>> GetAllPagesAsync<TResponse, TItem>(
        string path,
        Func<TResponse, List<TItem>?> itemsSelector,
        IDictionary<string, string?>? query = null,
        int limit = 50,
        CancellationToken ct = default)
        where TResponse : SourcePagedResponse;

    /// <summary>Faz login com as configurações atuais. Usado no botão de teste e no arranque.</summary>
    Task TestConnectionAsync(CancellationToken ct = default);
}
