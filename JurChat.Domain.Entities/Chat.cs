namespace JurChat.Domain.Entities
{
    public class Chat : IEntity<int>
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;
        
        public User Owner { get; set; } = null!;

        public List<User> Participants { get; set; } = new();
    }
}
