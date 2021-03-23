using Microsoft.AspNetCore.Mvc;
using SignalRDemo.Client.Web.Services;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Controllers
{
    [Route("[controller]")]
    public class VoteController : ControllerBase
    {
        private readonly IVoteManager _voteManager;

        public VoteController(IVoteManager voteManager)
        {
            _voteManager = voteManager;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Pie()
        {
            await _voteManager.CastVoteAsync("pie");

            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Bacon()
        {
            await _voteManager.CastVoteAsync("bacon");

            return Ok();
        }
    }
}
