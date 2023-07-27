using System;

namespace JurChat.Client.Models
{
    public class Conversation
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LastMessage { get; set; }
        public DateTime LastMessageDateTime { get; set; }
        public string Photo { get; set; }
    }
}
