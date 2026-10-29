namespace Integrador.Integration.Contracts;

/// <summary>
/// Ponto de entrada da integração origem -> destino. Usado pelo botão manual e pelo modo AUTO.
/// </summary>
public interface IIntegrationRunner
{
    bool IsRunning { get; }

    Task RunAsync(IntegrationTrigger trigger = IntegrationTrigger.Manual, CancellationToken ct = default);
}
