using Integrador.Common.Logging;
using Integrador.Source.Contracts;
using Integrador.Integration.Contracts;
using Integrador.Integration.Infrastructure;

namespace Integrador.Integration.Application;

internal sealed class IntegrationRunner(ISourceApiClient source, IIntegrationLogger logger, FileIntegrationRunHistory history) : IIntegrationRunner
{
    private const string Source = nameof(IntegrationRunner);

    // Impede execução manual e agendada em simultâneo dentro do mesmo processo
    private static readonly SemaphoreSlim _running = new(1, 1);

    public bool IsRunning => _running.CurrentCount == 0;

    public async Task RunAsync(IntegrationTrigger trigger = IntegrationTrigger.Manual, CancellationToken ct = default)
    {
        if (!await _running.WaitAsync(0, ct))
            throw new InvalidOperationException("Já existe uma integração em curso.");

        DateTime startedAt = DateTime.Now;

        try
        {
            await logger.InfoAsync(Source, $"Início da integração origem -> destino ({trigger})");

            await source.TestConnectionAsync(ct);

            // TODO: obter dados da origem, transformar (Domain/) e enviar para o destino

            await logger.InfoAsync(Source, "Fim da integração origem -> destino");
            await history.AddAsync(new IntegrationRun(startedAt, DateTime.Now, trigger, IntegrationRunStatus.Success, null));
        }
        catch (Exception ex)
        {
            await history.AddAsync(new IntegrationRun(startedAt, DateTime.Now, trigger, IntegrationRunStatus.Failed, ex.GetBaseException().Message));
            throw;
        }
        finally
        {
            _running.Release();
        }
    }
}
