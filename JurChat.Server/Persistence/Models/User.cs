using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JurChat.Server.Persistence.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string FatherName { get; set; }

        public string Telephone { get; set; }

        [Required]
        public string Mail { get; set; }

        public string Photo { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime LastVisitDateTime { get; set; }

        public List<Project> Projects { get; set; } = new();

        public List<Chat> Chats { get; set; } = new();
    }
}
