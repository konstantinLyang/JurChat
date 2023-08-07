namespace JurChat.Server.Services.Contracts
{
    public class MessageFileDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string ServerFilePath { get; set; } = null!;

        public bool IsImage { get; set; }
    }
}
