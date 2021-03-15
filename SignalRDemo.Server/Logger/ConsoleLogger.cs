using Microsoft.Extensions.Logging;
using System;

namespace SignalRDemo.Server.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!IsEnabled(logLevel))
                return;

            var log =
                $"{"[" + DateTimeOffset.UtcNow.ToString("yyyy-MM-dd HH:mm:ss") + "]"} [{logLevel}] {formatter(state, exception)}";

            Console.WriteLine(log);
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel != LogLevel.None;

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
    }
}