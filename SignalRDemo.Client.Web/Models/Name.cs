using System.Text.Json.Serialization;

namespace SignalRDemo.Client.Web.Models
{
    public class Name
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("first")]
        public string First { get; set; }

        [JsonPropertyName("last")]
        public string Last { get; set; }
    }
}