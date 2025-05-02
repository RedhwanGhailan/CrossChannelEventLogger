namespace EventLoggerLib.Logging;

public class FileLogger(string filePath) : ILogger
{
    private readonly string _filePath = filePath;

    private static readonly SemaphoreSlim _fileLock = new(1, 1);

    public async Task LogAsync(LogModel entry)
    {
        var logLine = $"[{entry.Timestamp:O}] {entry.Level}: {entry.Message}{Environment.NewLine}";

        await _fileLock.WaitAsync();
        try
        {
            await File.AppendAllTextAsync(_filePath, logLine);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"FileLogger Exception: {ex.Message}");
        }
        finally
        {
            _fileLock.Release();
        }
    }
}


