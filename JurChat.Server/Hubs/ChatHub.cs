using JurChat.Server.Hubs.Infrastructure;
using Microsoft.AspNetCore.SignalR;

namespace JurChat.Server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatHubManager _chatHubManager;

        public ChatHub(ChatHubManager hubManager)
        {
            _chatHubManager = hubManager;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await base.OnDisconnectedAsync(exception);
        }
    }
}
