namespace Domain.Entities
{
    public class User : IEntity<int>
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? FatherName { get; set; } = null;

        public string? Telephone { get; set; } = null;
        
        public string Mail { get; set; } = null!;

        public string? Photo { get; set; } = null;
        
        public string Password { get; set; } = null!;

        public bool Deleted { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime LastVisitDateTime { get; set; }

        public List<Project> Projects { get; set; } = new();

        public List<Chat> Chats { get; set; } = new();
    }
}
