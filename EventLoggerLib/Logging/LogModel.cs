using System.Text.Json.Serialization;

namespace EventLoggerLib.Logging;

public class LogModel
{
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public required string Message { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public required LogLevel Level { get; set; }
}

public enum LogLevel
{
    Trace,
    Debug,
    Information,
    Warning,
    Error,
    Critical
}

