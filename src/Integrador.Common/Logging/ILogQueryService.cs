namespace Integrador.Common.Logging;

public interface ILogQueryService
{
    Task<List<IntegratorLog>> GetFilteredAsync(LogLevel level, DateTime? startDate, DateTime? endDate);
}
