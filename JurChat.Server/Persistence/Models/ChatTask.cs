using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JurChat.Server.Persistence.Models
{
    public class ChatTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;

        [Required]
        public DateTime CreateDateTime { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        public DateTime DoneDateTime { get; set; }

        public DateTime DeadLineDateTime { get; set; }

        public Project? Project { get; set; } = null;

        [Required]
        [ForeignKey("ProducerId")]
        public User Producer { get; set; } = null!;
        public int ProducerId { get; set; }

        [Required]
        [ForeignKey("ExecutorId")]
        public User Executor { get; set; } = null!;
        public int ExecutorId { get; set; }
    }
}
