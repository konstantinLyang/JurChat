using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JurChat.Client.Persistence.Models
{
    public class Chat
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;

        [Required]
        [ForeignKey("OwnerId")]
        public User Owner { get; set; } = null!;
        public int OwnerId { get; set; }

        public List<User> Participants { get; set; } = new();
    }
}
