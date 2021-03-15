using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Hubs
{
    public class AccountHub : Hub
    {
        public async Task JoinUser(string forename, string surname)
        {
            var fullname = $"{forename} {surname}";

            await Clients.Others.SendAsync("Introduce", fullname);
            await Clients.Caller.SendAsync("Introduce", fullname);
        }
    }
}
