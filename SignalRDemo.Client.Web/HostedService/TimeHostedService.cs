using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using SignalRDemo.Client.Web.Hubs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.HostedService
{
    public class TimeHostedService : IHostedService, IDisposable
    {
        private readonly IHubContext<TimeHub> _timeHubContext;
        private Timer _timer;

        public TimeHostedService(IHubContext<TimeHub> timeHubContext)
        {
            _timeHubContext = timeHubContext;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Tick, null, TimeSpan.Zero, TimeSpan.FromMilliseconds(500));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public virtual void Dispose() => _timer?.Dispose();

        private void Tick(object state)
        {
            var currentTime = DateTime.UtcNow.ToString("F");

            _timeHubContext.Clients.All.SendAsync("UpdateCurrentTime", currentTime);
        }
    }
}
