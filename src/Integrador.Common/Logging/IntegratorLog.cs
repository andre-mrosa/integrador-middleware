namespace Integrador.Common.Logging;

public sealed class IntegratorLog
{
    public DateTime LoggedAt { get; set; }
    public LogLevel Level { get; set; }
    public string? Source { get; set; }
    public string? Message { get; set; }
    public string? Exception { get; set; }
    public string? Payload { get; set; } // JSON do pedido/resposta ou dados em bruto para diagnóstico
}
