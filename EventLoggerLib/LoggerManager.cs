using EventLoggerLib.Logging;

namespace EventLoggerLib;

public class LoggerManager
{
    private readonly List<ILogger> _loggers = [];

    public void AddLogger(ILogger logger)
    {
        _loggers.Add(logger);
    }

    public async Task ParallelLogAsync(string message, LogLevel level = LogLevel.Information)
    {
        var entry = new LogModel { Message = message, Level = level };

        await Parallel.ForEachAsync(_loggers, async (logger, _) =>
        {
            await logger.LogAsync(entry);
        });
    }
}





