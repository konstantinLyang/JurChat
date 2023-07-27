using JurChat.Network.Models;

namespace JurChat.Network
{
    public interface IConnection
    {
        public event EventHandler<PackageMessage> MessageReceived;

        public Task SendMessageAsync(PackageMessage packageMessage);

        public bool IsConnected { get; }

        public void Connect(string ip, int port);

        public void Disconnect();
    }
}
