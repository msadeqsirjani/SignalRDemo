using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Services
{
    public interface IVoteManager
    {
        Task CastVoteAsync(string voteFor);
        Task<Dictionary<string, int>> GetCurrentVotesAsync();
    }
}
