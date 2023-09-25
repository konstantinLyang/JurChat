using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Presentation.App.Services.Interfaces
{
    public interface IClientService
    {
        public HubConnection Connection { get; set; }
        public Task<bool> Connect();
        public Task<bool> Disconnect();
        public Task<bool> Authorize(string login, string password);
    }
}
