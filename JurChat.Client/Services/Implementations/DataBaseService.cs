using System.Collections.Generic;
using System.Linq;
using JurChat.Client.Models;
using JurChat.Client.Persistance;
using JurChat.Client.Services.Interfaces;

namespace JurChat.Client.Services.Implementations
{
    public class DataBaseService : IDataBaseService
    {
        private readonly AppContext _dbContext;
        

        public Chat GetChatById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Models.Client GetClientById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Message GetMessageById(string id)
        {
            throw new System.NotImplementedException();
        }

        public File GetFileById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Role GetRoleById(string id)
        {
            throw new System.NotImplementedException();
        }

        public List<Conversation> GetConversationList()
        {
            List<Conversation> result = new();

            var clients = _dbContext.Clients;
            var chats = _dbContext.Chats;

            /*foreach (var client in clients)
            {
                var lastMessage = _dbContext.Messages.Last(x => x.Recipient.Id == client.Id && x.Sender.Id == _currentClient.UserData.Id);
                result.Add(new()
                {
                    Id = client.Id,
                    Name = $"{client.LastName} {client.FirstName} {client.FatherName}",
                    LastMessage = lastMessage.Text,
                    LastMessageDateTime = lastMessage.CreationDateTime,
                    Photo = client.Photo
                });
            }

            foreach (var chat in chats)
            {
                var lastMessage = _dbContext.Messages.Last(x => x.Chat.Id == chat.Id && x.Sender.Id == _currentClient.UserData.Id);
                result.Add(new()
                {
                    Id = chat.Id,
                    Name = chat.Name,
                    LastMessage = lastMessage.Text,
                    LastMessageDateTime = lastMessage.CreationDateTime,
                    Photo = chat.Photo
                });
            }*/

            return result;
        }

        public DataBaseService()
        {
            _dbContext = new();
        }
    }
}
