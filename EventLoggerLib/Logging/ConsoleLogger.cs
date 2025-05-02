namespace EventLoggerLib.Logging;

public class ConsoleLogger : ILogger
{
    public Task LogAsync(LogModel entry)
    {
        return Task.Run(() =>
            Console.WriteLine($"[{entry.Timestamp}] {entry.Level}: {entry.Message}")
        );
    }
}



