using EventLoggerLib.Logging;

namespace EventLoggerLib.Tests;

[TestClass]
public class FileLoggerTests
{
    [TestMethod]
    public async Task LogAsync_WritesLogToFile()
    {
        var tempFile = Path.GetTempFileName();
        var logger = new FileLogger(tempFile);

        var logModel = new LogModel
        {
            Timestamp = new DateTime(2025, 5, 2, 15, 30, 0),
            Level = LogLevel.Warning,
            Message = "ESP RG: Test File logger!"
        };

        await logger.LogAsync(logModel);

        var content = File.ReadAllText(tempFile);
        StringAssert.Contains(content, "ESP RG: Test File logger!");
        StringAssert.Contains(content, "Warning");
        StringAssert.Contains(content, "2025-05-02");

        File.Delete(tempFile);
    }
}

