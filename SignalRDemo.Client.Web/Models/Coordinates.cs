using System.Text.Json.Serialization;

namespace SignalRDemo.Client.Web.Models
{
    public class Coordinates
    {
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }
    }
}