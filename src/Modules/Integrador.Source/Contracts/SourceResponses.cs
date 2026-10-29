namespace Integrador.Source.Contracts;

public class SourceResponse
{
    public bool? Error { get; set; }
    public string? Message { get; set; }
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
