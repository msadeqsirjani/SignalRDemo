using Microsoft.Extensions.Logging;

namespace SignalRDemo.Client.Web.Logger
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
