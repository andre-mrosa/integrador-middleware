namespace Integrador.Integration.Contracts;

public enum IntegrationTrigger
{
    Manual,
    Auto
}

public enum IntegrationRunStatus
{
    Success,
    Failed
}

/// <summary>
/// Registo de uma execução do integrador (histórico mostrado no Início).
/// </summary>
public sealed record IntegrationRun(
    DateTime StartedAt,
    DateTime FinishedAt,
    IntegrationTrigger Trigger,
    IntegrationRunStatus Status,
    string? Message)
{
    public TimeSpan Duration => FinishedAt - StartedAt;
}

public interface IIntegrationRunHistory
{
    /// <summary>Execuções mais recentes primeiro.</summary>
    Task<List<IntegrationRun>> GetRecentAsync(int count = 50);
}
