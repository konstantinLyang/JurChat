using System.ComponentModel.DataAnnotations;

namespace JurChat.Client.Persistence.Models
{
    public class MessageFile
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string ServerFilePath { get; set; } = null!;

        public bool IsImage { get; set; }
    }
}
