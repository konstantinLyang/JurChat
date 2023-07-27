namespace JurChat.Network.Models
{
    internal class Header
    {
        public MessageType MessageType { get; set; }

        public StatusCode StatusCode { get; set; }

        public string[]? CommandArguments { get; set; } = new string[5];
    }
}
