using System.Collections.Generic;

namespace LuisAI_XamarinForms.Models
{
    public class Luis
    {
        public string type { get; set; }
        public string id { get; set; }
        public string timestamp { get; set; }
        public string localTimestamp { get; set; }
        public string serviceUrl { get; set; }
        public string channelId { get; set; }
        public From from { get; set; }
        public Conversation conversation { get; set; }
        public Recipient recipient { get; set; }
        public string textFormat { get; set; }
        public List<object> membersAdded { get; set; }
        public List<object> membersRemoved { get; set; }
        public string locale { get; set; }
        public string text { get; set; }
        public List<object> attachments { get; set; }
        public List<Entity> entities { get; set; }
        public ChannelData channelData { get; set; }
    }

    public partial class From
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Conversation
    {
        public string id { get; set; }
    }

    public class Recipient
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Entity
    {
        public string type { get; set; }
        public bool requiresBotState { get; set; }
        public bool supportsTts { get; set; }
        public bool supportsListening { get; set; }
    }

    public class ChannelData
    {
        public string clientActivityId { get; set; }
    }
}