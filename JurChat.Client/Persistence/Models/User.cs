using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JurChat.Client.Persistence.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required] public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        public string? FatherName { get; set; } = null;

        public string? Telephone { get; set; } = null;

        [Required]
        public string Mail { get; set; } = null!;

        public string? Photo { get; set; } = null;

        [Required]
        public string Password { get; set; } = null!;

        public DateTime CreateDateTime { get; set; }

        public DateTime LastVisitDateTime { get; set; }

        public List<Project> Projects { get; set; } = new();

        public List<Chat> Chats { get; set; } = new();
    }
}
