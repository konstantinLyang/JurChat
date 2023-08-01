using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JurChat.Server.Persistence.Models
{
    public class ChatTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime CreateDateTime { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        public DateTime DoneDateTime { get; set; }

        public DateTime DeadLineDateTime { get; set; }

        public Project Project { get; set; }

        [Required]
        [ForeignKey("ProducerId")]
        public User Producer { get; set; }
        public int ProducerId { get; set; }

        [Required]
        [ForeignKey("ExecutorId")]
        public User Executor { get; set; }
        public int ExecutorId { get; set; }
    }
}
