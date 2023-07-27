using System.Collections.Generic;
using JurChat.Client.Models;

namespace JurChat.Client.Services.Interfaces
{
    public interface IDataBaseService
    {
        public Chat GetChatById(string id);
        public Models.Client GetClientById(string id);
        public Message GetMessageById(string id);
        public File GetFileById(string id);
        public Role GetRoleById(string id);

        public List<Conversation> GetConversationList();
    }
}
