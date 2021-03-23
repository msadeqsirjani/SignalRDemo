using System.Text.Json.Serialization;

namespace SignalRDemo.Client.Web.Models
{
    public class Id
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
