namespace Integrador.Common.Logging;

public interface IIntegrationLogger
{
    Task WriteAsync(LogLevel level, string source, string message, string? exception = null, string? payload = null);

    Task InfoAsync(string source, string message, string? payload = null) => WriteAsync(LogLevel.INFO, source, message, null, payload);
    Task WarningAsync(string source, string message, string? payload = null) => WriteAsync(LogLevel.WARNING, source, message, null, payload);
    Task ErrorAsync(string source, string message, Exception? ex = null, string? payload = null) => WriteAsync(LogLevel.ERROR, source, message, ex?.ToString(), payload);
    Task CriticalAsync(string source, string message, Exception? ex = null, string? payload = null) => WriteAsync(LogLevel.CRITICAL, source, message, ex?.ToString(), payload);
}
