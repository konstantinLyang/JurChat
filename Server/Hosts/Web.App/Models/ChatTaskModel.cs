namespace Web.App.Models
{
    public class ChatTaskModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime StartDateTime { get; set; }

        public DateTime DoneDateTime { get; set; }

        public DateTime DeadLineDateTime { get; set; }

        public ProjectModel? Project { get; set; } = null;
        
        public UserModel Producer { get; set; } = null!;
        
        public UserModel Executor { get; set; } = null!;
    }
}
