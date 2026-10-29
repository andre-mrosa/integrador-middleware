using Integrador.Integration.Contracts;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Integrador.Integration.Infrastructure;

/// <summary>
/// Histórico de execuções em History/runs.log (JSON Lines) ao lado do executável.
/// Mantém só as últimas MaxEntries para o ficheiro não crescer indefinidamente.
/// </summary>
internal sealed class FileIntegrationRunHistory : IIntegrationRunHistory
{
    private const int MaxEntries = 500;

    private static readonly string _filePath = Path.Combine(AppContext.BaseDirectory, "History", "runs.log");
    private static readonly SemaphoreSlim _lock = new(1, 1);

    private static readonly JsonSerializerOptions _json = new()
    {
        Converters = { new JsonStringEnumConverter() },
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    public async Task AddAsync(IntegrationRun run)
    {
        await _lock.WaitAsync();
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_filePath)!);

            var lines = File.Exists(_filePath) ? (await File.ReadAllLinesAsync(_filePath)).ToList() : [];
            lines.Add(JsonSerializer.Serialize(run, _json));

            if (lines.Count > MaxEntries)
                lines = lines[^MaxEntries..];

            await File.WriteAllLinesAsync(_filePath, lines);
        }
        catch
        {
            // Histórico é informativo, nunca pode rebentar a integração
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task<List<IntegrationRun>> GetRecentAsync(int count = 50)
    {
        if (!File.Exists(_filePath))
            return [];

        List<IntegrationRun> runs = [];

        using var stream = new FileStream(_filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
        using var reader = new StreamReader(stream);

        while (await reader.ReadLineAsync() is { } line)
        {
            try
            {
                var run = JsonSerializer.Deserialize<IntegrationRun>(line, _json);
                if (run != null) runs.Add(run);
            }
            catch (JsonException)
            {
                // Linha corrompida, ignora
            }
        }

        return [.. runs.OrderByDescending(r => r.StartedAt).Take(count)];
    }
}
