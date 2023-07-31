namespace JurChat.Server.Hubs.Infrastructure
{
    public class ChatHubManager
    {
        public List<UserConnection> ConnectedUsers { get; set; } = new();
    }
}
