namespace JurChat.Domain.Entities
{
    public class MessageFile : IEntity<int>
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string ServerFilePath { get; set; } = null!;

        public bool IsImage { get; set; }
    }
}
