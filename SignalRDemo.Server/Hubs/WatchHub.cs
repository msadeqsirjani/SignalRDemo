using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRDemo.Server.Hubs
{
    public class WatchHub : Hub
    {
        private static int _watchingMember;

        public async Task Watch()
        {
            await Clients.All.SendAsync("Update", _watchingMember++);
        }
    }
}
