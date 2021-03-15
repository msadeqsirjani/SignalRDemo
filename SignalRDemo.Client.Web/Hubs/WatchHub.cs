using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Hubs
{
    public class WatchHub : Hub
    {
        private static int _watchingMember;

        public async Task Watch()
        {
            await Clients.All.SendAsync("View", _watchingMember++);
        }
    }
}
