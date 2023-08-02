using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace JurChat.Client.Services.Interfaces
{
    public interface IClientService
    {
        public HubConnection Connection { get; set; }
        public Task<bool> Connect();
        public Task<bool> Disconnect();
        public Task<bool> Authorized(string login, string password);
    }
}
