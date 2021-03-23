using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SignalRDemo.Client.Web.Models
{
    public class RandomUserRoot
    {
        [JsonPropertyName("results")]
        public List<RandomUser> Results { get; set; }

        [JsonPropertyName("info")]
        public Info Info { get; set; }
    }
}