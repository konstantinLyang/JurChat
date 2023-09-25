namespace JurChat.Web.Models
{
    public class ChatModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;
        
        public UserModel Owner { get; set; } = null!;

        public List<UserModel> Participants { get; set; } = new();
    }
}
