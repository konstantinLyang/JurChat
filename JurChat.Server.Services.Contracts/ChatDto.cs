namespace JurChat.Server.Services.Contracts
{
    public class ChatDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;
        
        public UserDto Owner { get; set; } = null!;

        public List<UserDto> Participants { get; set; } = new();
    }
}
