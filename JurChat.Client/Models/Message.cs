using System;

namespace JurChat.Client.Models
{
    public class Message
    {
        public string Id { get; set; }
        public Client Sender { get; set; }
        public Client Recipient { get; set; }
        public Chat Chat { get; set; }
        public string Text { get; set; }
        public File File { get; set; }
        public bool IsFile { get; set; }
        public bool IsImage { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ReaDateTime { get; set; }
    }
}
