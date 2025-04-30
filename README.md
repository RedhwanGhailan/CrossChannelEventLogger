# CrossChannelEventLogger
A reusable and lightweight .NET Class Library for **asynchronous application event logging** to **multiple output channels** such as Console and File. Designed without any third-party logging libraries to ensure full transparency and maximum control.

---

## 📦 Features

- 1 Log events to multiple channels (Console, File, and event stream.)
- 2 Non-blocking, asynchronous logging using `Task`
- 3 Easily extensible — implement your own loggers
- 4 Clean architecture with separation of concerns
- 5 No external dependencies (no NLog, Serilog, etc.)

---

## 🧠 How It Works

The library is based on the **Strategy Pattern** and includes:
- A `LogEntry` class to standardize the log structure.
- An `ILogger` interface that all channels implement.
- Concrete logger implementations like `ConsoleLogger` and `FileLogger`.
- A `LoggerManager` class that dispatches each log message to **all registered channels** asynchronously.

Each time you call `LogAsync(...)`, the `LoggerManager`:
1. Creates a `LogEntry` with timestamp, level, and message.
2. Calls `LogAsync` on every registered logger (e.g., console, file).
3. All logging happens **concurrently and non-blocking** using `Task.WhenAll`.

---

## 🏗️ Project Structure

