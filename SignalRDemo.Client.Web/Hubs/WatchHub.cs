using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Hubs
{
    public class WatchHub : Hub<IWatchHubClient>
    {
        private static int _watchingMember;

        public override async Task OnConnectedAsync()
        {
            await Clients.All.View(++_watchingMember);

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await Clients.All.View(--_watchingMember);

            await base.OnDisconnectedAsync(exception);
        }
    }

    public interface IWatchHubClient
    {
        Task View(int viewer);
    }
}
