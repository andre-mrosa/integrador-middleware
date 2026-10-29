namespace Integrador.Source.Contracts;

/// <summary>
/// Erro de negócio da API de origem: resposta HTTP 200 com { "error": "true", "message", "type"? }.
/// </summary>
// TODO: formato de erro do exemplo de adapter. Adaptar ao da API real
public sealed class SourceApiException(string path, string message, string? type = null)
    : Exception($"A API de origem devolveu erro em {path}: {message}")
{
    public string Path { get; } = path;

    /// <summary>Código estável do erro quando a API o manda (ex: REFERENCE_NOT_FOUND). Null nos restantes.</summary>
    public string? Type { get; } = type;

    /// <summary>Mensagem da API, sem o prefixo.</summary>
    public string Detail { get; } = message;
}
