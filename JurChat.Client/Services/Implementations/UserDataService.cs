using Microsoft.AspNetCore.SignalR.Client;

namespace JurChat.Client.Services.Implementations
{
    public class UserDataService
    {
        public HubConnection? Connection { get; set; }

        public void Authorization()
        {

        }

        public bool Connect()
        {
            Connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7244/chat")
                .Build();
            Connection.StartAsync();

            return true;
        }

        public bool Disconnect()
        {
            return true;
        }
    }
}
