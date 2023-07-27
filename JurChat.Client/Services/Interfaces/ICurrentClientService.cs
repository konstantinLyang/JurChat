using JurChat.Client.Models;

namespace JurChat.Client.Services.Interfaces
{
    public interface ICurrentClientService
    {
        public UserData UserData { get; set; }
    }
}
