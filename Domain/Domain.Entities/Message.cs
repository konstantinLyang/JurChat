namespace Domain.Entities
{
    public class Message : IEntity<int>
    {
        public int Id { get; set; }
        
        public User Sender { get; set; } = null!;

        public User Recipient { get; set; } = null!;
        
        public Chat Chat { get; set; } = null!;
        
        public ChatTask Task { get; set; } = null!;
        
        public Project Project { get; set; } = null!;

        public string? Text { get; set; } = null;

        public MessageFile? File { get; set; } = null;
        
        public DateTime CreatedDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public bool IsRead { get; set; }

        public bool IsEdit { get; set; }
    }
}
