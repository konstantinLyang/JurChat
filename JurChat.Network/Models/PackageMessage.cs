namespace JurChat.Network.Models
{
    public class PackageMessage
    {
        public Header Header { get; set; }
        public byte[] Data { get; set; }
    }
}
