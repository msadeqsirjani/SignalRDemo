using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Client.Web.Models;
using SignalRDemo.Client.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Hubs
{
    public class UserHub : Hub
    {
        private readonly IRandomUserService _randomUserService;

        public UserHub(IRandomUserService randomUserService)
        {
            _randomUserService = randomUserService;
        }

        public async Task<IEnumerable<RandomUser>> GetUsers(int max = 1)
        {
            return await _randomUserService.GetUsers(max);
        }
    }
}
