namespace JurChat.Server.Services.Contracts
{
    public class MessageDto
    {
        public int Id { get; set; }
        
        public UserDto Sender { get; set; } = null!;

        public UserDto Recipient { get; set; } = null!;
        
        public ChatDto Chat { get; set; } = null!;
        
        public ChatTaskDto Task { get; set; } = null!;
        
        public ProjectDto Project { get; set; } = null!;

        public string? Text { get; set; } = null;

        public MessageFileDto? File { get; set; } = null;
        
        public DateTime CreatedDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public bool IsRead { get; set; }

        public bool IsEdit { get; set; }
    }
}
