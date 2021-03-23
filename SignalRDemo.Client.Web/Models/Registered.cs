using System;
using System.Text.Json.Serialization;

namespace SignalRDemo.Client.Web.Models
{
    public class Registered
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}