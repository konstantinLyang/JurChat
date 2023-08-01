using System.ComponentModel.DataAnnotations;

namespace JurChat.Server.Persistence.Models
{
    public class MessageFile
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string ServerFilePath { get; set; }

        public bool IsImage { get; set; }
    }
}
