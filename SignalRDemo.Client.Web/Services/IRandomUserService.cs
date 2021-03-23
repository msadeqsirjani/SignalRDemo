using SignalRDemo.Client.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRDemo.Client.Web.Services
{
    public interface IRandomUserService
    {
        Task<IEnumerable<RandomUser>> GetUsers(int max = 10);
    }
}
