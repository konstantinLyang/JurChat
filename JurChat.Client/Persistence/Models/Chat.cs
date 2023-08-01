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
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [ForeignKey("OwnerId")]
        public User Owner { get; set; }
        public int OwnerId { get; set; }

        public List<User> Participants { get; set; } = new();
    }
}
