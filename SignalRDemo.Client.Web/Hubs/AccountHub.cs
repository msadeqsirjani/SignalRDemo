using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Hubs
{
    public class AccountHub : Hub<IAccountHubClient>
    {
        public async Task JoinUser(string forename, string surname)
        {
            var fullname = $"{forename} {surname}";

            await Clients.Others.Introduce(fullname);
            await Clients.Caller.Introduce(fullname);
        }
    }

    public interface IAccountHubClient
    {
        Task Introduce(string fullname);
    }
}
