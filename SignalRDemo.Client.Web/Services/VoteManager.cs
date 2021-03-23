using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Client.Web.Hubs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Services
{
    public class VoteManager : IVoteManager
    {
        private static Dictionary<string, int> _votes;
        private readonly IHubContext<VoteHub> _voteHubContext;

        public VoteManager()
        {
            _votes = new Dictionary<string, int>
            {
                {"pie", 0},
                {"bacon", 0}
            };
        }

        public VoteManager(IHubContext<VoteHub> voteHubContext) : this()
        {
            _voteHubContext = voteHubContext;
        }

        public async Task CastVoteAsync(string voteFor)
        {
            _votes[voteFor]++;

            await _voteHubContext.Clients.All.SendAsync("UpdateVotes", _votes);
        }

        public Task<Dictionary<string, int>> GetCurrentVotesAsync() => Task.FromResult(_votes);
    }
}