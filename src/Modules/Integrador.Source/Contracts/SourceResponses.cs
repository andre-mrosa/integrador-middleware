namespace Integrador.Source.Contracts;

public class SourceResponse
{
    /// <summary>A API manda "true"/"false" em texto. Erros de negócio vêm com HTTP 200 e error = true.</summary>
    public bool? Error { get; set; }
    public string? Message { get; set; }

    /// <summary>Código estável de alguns erros, quando a API o manda (ex: REFERENCE_NOT_FOUND).</summary>
    public string? Type { get; set; }
}

/// <summary>
/// Base dos endpoints paginados (GET /projects, /project-steps, /products, /clients).
/// </summary>
public class SourcePagedResponse : SourceResponse
{
    public string? NextToken { get; set; }
    public int? Size { get; set; }
    public int? DataSize { get; set; }
    public int? Page { get; set; }
}
