using System.Text.Json.Serialization;

namespace SignalRDemo.Client.Web.Models
{
    public class Street
    {
        [JsonPropertyName("number")]
        public int Number { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}