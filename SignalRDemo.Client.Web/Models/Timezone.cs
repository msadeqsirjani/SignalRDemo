using System.Text.Json.Serialization;

namespace SignalRDemo.Client.Web.Models
{
    public class Timezone
    {
        [JsonPropertyName("offset")]
        public string Offset { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}