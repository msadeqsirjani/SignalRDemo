using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Hubs
{
    public class ColorHub : Hub<IColorHubClient>
    {
        public async Task JoinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task RemoveGroup(string groupName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task TriggerGroup(string groupName)
        {
            await Clients.Group(groupName).TriggerColor(groupName);
        }
    }

    public interface IColorHubClient
    {
        Task TriggerColor(string groupName);
    }
}
