namespace JurChat.Domain.Entities
{
    public class ChatTask : IEntity<int>
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime StartDateTime { get; set; }

        public DateTime DoneDateTime { get; set; }

        public DateTime DeadLineDateTime { get; set; }

        public Project? Project { get; set; } = null;
        
        public User Producer { get; set; } = null!;
        
        public User Executor { get; set; } = null!;
    }
}
