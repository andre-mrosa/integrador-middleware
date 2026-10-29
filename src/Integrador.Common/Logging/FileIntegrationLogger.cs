using System.Text.Json;
using System.Text.Json.Serialization;

namespace Integrador.Common.Logging;

/// <summary>
/// Logs em ficheiros diários JSON Lines (Logs/yyyy-MM-dd.log ao lado do executável).
/// Uma linha por registo, fácil de ler na UI e de abrir num editor.
/// </summary>
internal sealed class FileIntegrationLogger : IIntegrationLogger, ILogQueryService
{
    private const int RetentionDays = 90;

    private static readonly string _folder = Path.Combine(AppContext.BaseDirectory, "Logs");
    private static readonly SemaphoreSlim _lock = new(1, 1);

    private static readonly JsonSerializerOptions _json = new()
    {
        Converters = { new JsonStringEnumConverter() },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    private DateOnly _lastCleanup = DateOnly.MinValue;

    #region ESCRITA

    public async Task WriteAsync(LogLevel level, string source, string message, string? exception = null, string? payload = null)
    {
        var log = new IntegratorLog
        {
            LoggedAt = DateTime.Now,
            Level = level,
            Source = source,
            Message = message,
            Exception = exception,
            Payload = payload
        };

        string line = JsonSerializer.Serialize(log, _json);

        await _lock.WaitAsync();
        try
        {
            Directory.CreateDirectory(_folder);
            // FileShare.ReadWrite: a UI e uma execução AUTO podem escrever ao mesmo tempo
            await using var stream = new FileStream(FilePath(DateOnly.FromDateTime(log.LoggedAt)), FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            await using var writer = new StreamWriter(stream);
            await writer.WriteLineAsync(line);
            CleanupOldFiles();
        }
        catch
        {
            // Logging nunca pode rebentar a integração
        }
        finally
        {
            _lock.Release();
        }
    }

    private void CleanupOldFiles()
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        if (_lastCleanup == today) return;
        _lastCleanup = today;

        foreach (var file in Directory.EnumerateFiles(_folder, "*.log"))
        {
            if (DateOnly.TryParseExact(Path.GetFileNameWithoutExtension(file), "yyyy-MM-dd", out var date) && date < today.AddDays(-RetentionDays))
                File.Delete(file);
        }
    }

    #endregion

    #region LEITURA

    public async Task<List<IntegratorLog>> GetFilteredAsync(LogLevel level, DateTime? startDate, DateTime? endDate)
    {
        var from = DateOnly.FromDateTime(startDate ?? DateTime.Today.AddDays(-RetentionDays));
        var to = DateOnly.FromDateTime(endDate ?? DateTime.Today);

        List<IntegratorLog> logs = [];

        for (var day = from; day <= to; day = day.AddDays(1))
        {
            string path = FilePath(day);
            if (!File.Exists(path)) continue;

            // FileShare.ReadWrite para ler enquanto outra instância (AUTO) escreve
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using var reader = new StreamReader(stream);

            while (await reader.ReadLineAsync() is { } line)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                IntegratorLog? log;
                try { log = JsonSerializer.Deserialize<IntegratorLog>(line, _json); }
                catch (JsonException) { continue; }

                if (log != null && (level == LogLevel.ALL || log.Level == level))
                    logs.Add(log);
            }
        }

        return [.. logs.OrderByDescending(l => l.LoggedAt)];
    }

    #endregion

    private static string FilePath(DateOnly day) => Path.Combine(_folder, $"{day:yyyy-MM-dd}.log");
}
