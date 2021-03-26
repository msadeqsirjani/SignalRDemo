using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Hubs
{
    public class TimeHub : Hub<ITimeHubClient>
    {
    }

    public interface ITimeHubClient
    {
        Task UpdateCurrentTime(DateTime currentTime);
    }
}
