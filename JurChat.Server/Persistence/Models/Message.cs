using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JurChat.Server.Persistence.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("SenderId")]
        public User Sender { get; set; } = null!;
        public int SenderId { get; set; }

        [ForeignKey("RecipientId")]
        public User Recipient { get; set; } = null!;
        public int RecipientId { get; set; }

        [ForeignKey("ChatId")]
        public Chat Chat { get; set; } = null!;
        public int ChatId { get; set; }

        [ForeignKey("TaskId")]
        public ChatTask Task { get; set; } = null!;
        public int TaskId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; } = null!;
        public int ProjectId { get; set; }

        public string? Text { get; set; } = null;

        public MessageFile? File { get; set; } = null;

        [Required]
        public DateTime CreatedDateTime { get; set; }

        public DateTime EditDateTime { get; set; }

        public bool IsRead { get; set; }

        public bool IsEdit { get; set; }
    }
}
