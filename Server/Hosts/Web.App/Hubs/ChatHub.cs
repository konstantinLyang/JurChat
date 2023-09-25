using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Web.App.Hubs.Infrastructure;

namespace Web.App.Hubs
{
    [Authorize]
    public class ChatHub : Hub<IChatHub>
    {
        public ChatHub(ChatHubManager hubManager) => _chatHubManager = hubManager;
        
        private readonly ChatHubManager _chatHubManager;
        
        private const string DefaultGroupName = "KPPGROUP";

        #region Overrides

        public override async Task OnConnectedAsync()
        {
            _chatHubManager.ConnectUser(Guid.NewGuid().ToString(), Context.ConnectionId);

            await Groups.AddToGroupAsync(Context.ConnectionId, DefaultGroupName);
            await UpdateUsersAsync();
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            if(_chatHubManager.DisconnectUser(Context.ConnectionId)) await base.OnDisconnectedAsync(exception);

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, DefaultGroupName);
            await UpdateUsersAsync();
            await base.OnDisconnectedAsync(exception);
        }

        #endregion
        
        public async Task UpdateUsersAsync()
        {
            var users = _chatHubManager.ConnectedUsers.Select(x => x.Id).ToList();
            await Clients.All.UpdateUsersAsync(users);
        }

        public async Task SendPrivateMessageAsync(string senderId, string recipientId, byte[] message) =>
            await Clients.All.SendPrivateMessageAsync(senderId, recipientId, message);
    }

    public interface IChatHub
    {
        public Task UpdateUsersAsync(IEnumerable<string> users);
        public Task SendPrivateMessageAsync(string senderId, string recipientId, byte[] message);
    }
}
