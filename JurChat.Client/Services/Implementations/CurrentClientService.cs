using JurChat.Client.Models;
using JurChat.Client.Services.Interfaces;

namespace JurChat.Client.Services.Implementations
{
    public class CurrentClientService : ICurrentClientService
    {
        public CurrentClientService()
        {
        }

        public UserData UserData { get; set; }

    }
}
