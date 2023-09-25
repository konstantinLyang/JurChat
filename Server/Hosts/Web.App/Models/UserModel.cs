namespace Web.App.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        
        public string LastName { get; set; } = null!;

        public string? FatherName { get; set; } = null;

        public string? Telephone { get; set; } = null;
        
        public string Mail { get; set; } = null!;

        public string? Photo { get; set; } = null;
        
        public string Password { get; set; } = null!;

        public DateTime CreateDateTime { get; set; }

        public DateTime LastVisitDateTime { get; set; }

        public List<ProjectModel> Projects { get; set; } = new();

        public List<ChatModel> Chats { get; set; } = new();
    }
}
