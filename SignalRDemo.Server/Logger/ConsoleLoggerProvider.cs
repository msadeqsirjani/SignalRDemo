using Microsoft.Extensions.Logging;

namespace SignalRDemo.Server.Logger
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {

        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }
    }
}
