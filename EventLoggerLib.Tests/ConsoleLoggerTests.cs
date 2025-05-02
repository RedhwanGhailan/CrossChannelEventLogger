using EventLoggerLib.Logging;

namespace LoggerLib.Tests;


[TestClass]
public class ConsoleLoggerTests
{
    [TestMethod]
    public async Task LogAsync_WritesExpectedMessageToConsole()
    {
        var logger = new ConsoleLogger();
        var logModel = new LogModel
        {
            Timestamp = new DateTime(2025, 5, 02, 12, 0, 0),
            Level = LogLevel.Critical,
            Message = "ESP RG: Test Console logger!"
        };

        var strw = new StringWriter();
        try
        {
            Console.SetOut(strw);

            await logger.LogAsync(logModel);
            string output = strw.ToString();

            StringAssert.Contains(output, "ESP RG: Test Console logger!");
            StringAssert.Contains(output, "Critical");
            StringAssert.Contains(output, "5/2/2025");
        }
        finally
        {
            strw.Dispose();
        }
    }
}
