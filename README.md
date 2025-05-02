# CrossChannelEventLogger: Async & Thread-Safe Event logging to multiple channels with .NET 8

This project: is a reusable/lightweight .NET Class Library, provides a clean, extensible, and thread-safe logging system for .NET applications using `ILogger`. It supports asynchronous logging to muti outputs ( exmp. console, file), the project use concurrency safety (using the SemaphoreSlim method) and provides millisecond timestamps.

---

## Structure Design Choices

### 1. **`ILogger` Interface Based for: **
- Multiple logging implementations (exmp, file, console, cloud).
- make the system easir to **test, extend and maintain**
- The **dependency injection** mech

### 2. **(`LogLevel`) an enum type for: **
- Support **serialization** and **type safety** for logging APIs or configs

### 3. **(`LogAsync`) Async/parallel logging for:**
- uses `Parallel.ForEachAsync` to log entries concurrently across multiple logger
- parallel and async execution, improve performance in multiple logger channels
- high/large throughput/collections applications like multi-thread envs and web APIs

- Uses `Task`-based async methods to avoid blocking threads.
- Ideal for **web applications** and services handling concurrent requests

### 4. **`SemaphoreSlim` approch for **
- thread safety: prevents race conditions and file corruption from concurrent writes
- Async/Await: Ddesigned for these Scenarios and no thread starvation
- ensure that only one write operation occurs at a time, even across threads 

### 5. **extensible Design:**
- easy to add a new loggers like `DBLogger`, etc., without modifying existing code
- follow **Open/Closed Principle** from SOLID.

---

## How build/integrate and run: Example Usage
### 1. integrate and reference
- you can refernce the loggel lib to your project using the below: 

  `dotnet add reference ../CrossChannelEventLogger/EventLoggerLib/EventLoggerLib.csproj`
- with the namespace `EventLoggerLib.Logging`;

### 2. register the logger as servicce:
- To inject the custom ILogger to services or controller
  for example: register the FIleLoger as a singlwton:

  `services.AddSingleton<ILogger, FileLogger>(provider =>`
    `new FileLogger("app-log.txt"));`

### 3. build and run the code: 
- use `dotnet build` / `dotnet run`

