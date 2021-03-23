using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Client.Web.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Hubs
{
    public class VoteHub : Hub
    {
        private readonly IVoteManager _voteManager;

        public VoteHub(IVoteManager voteManager)
        {
            _voteManager = voteManager;
        }

        public async Task<Dictionary<string, int>> GetCurrentVotes()
        {
            return await _voteManager.GetCurrentVotesAsync();
        }
    }
}
