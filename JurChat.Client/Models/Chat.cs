using System.Collections.Generic;

namespace JurChat.Client.Models
{
    public class Chat
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public Client Owner { get; set; }
        public List<Client> Clients { get; set; }
    }
}
