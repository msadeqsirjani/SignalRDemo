using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Hubs
{
    public class BackgroundHub : Hub<IBackgroundHubClient>
    {
        public async Task NotifyChangingBackgroundColor(string color)
        {
            await Clients.All.ChangeBackgroundColor(color);
        }
    }

    public interface IBackgroundHubClient
    {
        Task ChangeBackgroundColor(string color);
    }
}
