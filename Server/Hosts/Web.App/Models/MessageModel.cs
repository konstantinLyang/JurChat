namespace Web.App.Models
{
    public class MessageModel
    {
        public int Id { get; set; }
        
        public UserModel Sender { get; set; } = null!;
        
        public UserModel Recipient { get; set; } = null!;
        
        public ChatModel Chat { get; set; } = null!;
        
        public ChatTaskModel Task { get; set; } = null!;
        
        public ProjectModel Project { get; set; } = null!;

        public string? Text { get; set; } = null;

        public MessageFileModel? File { get; set; } = null;

        public DateTime CreatedDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public bool IsRead { get; set; }

        public bool IsEdit { get; set; }
    }
}
