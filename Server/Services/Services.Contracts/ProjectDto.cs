namespace Services.Contracts
{
    public class ProjectDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;

        public string? Photo { get; set; } = null;
        
        public UserDto Owner { get; set; } = null!;

        public List<UserDto> Participants { get; set; } = new();
    }
}
