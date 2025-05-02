namespace EventLoggerLib.Logging;

public interface ILogger
{
    Task LogAsync(LogModel entry);
}
