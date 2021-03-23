using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SignalRDemo.Client.Web.Models;

namespace SignalRDemo.Client.Web.Services
{
    public class RandomUserService : IRandomUserService
    {
        private const string Url = "https://randomuser.me/api/";
        private readonly HttpClient _httpClient;

        public RandomUserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<RandomUser>> GetUsers(int max = 1)
        {
            if (max > 5000) max = 5000;

            var jsonResult = await _httpClient.GetStringAsync($"{Url}?results={max}");
            var randomUserRoot = JsonSerializer.Deserialize<RandomUserRoot>(jsonResult);

            return randomUserRoot.Results;
        }
    }
}