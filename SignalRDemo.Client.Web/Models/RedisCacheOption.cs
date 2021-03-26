namespace SignalRDemo.Client.Web.Models
{
    public class RedisCacheOption
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Url => $"{Host}:{Port}";
        public string ChannelPrefix { get; set; }
        public int DefaultDatabase { get; set; }
    }
}
