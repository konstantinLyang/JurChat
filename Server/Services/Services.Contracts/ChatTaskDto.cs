namespace Services.Contracts
{
    public class ChatTaskDto
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = null;
        
        public DateTime CreateDateTime { get; set; }
        
        public DateTime StartDateTime { get; set; }

        public DateTime DoneDateTime { get; set; }

        public DateTime DeadLineDateTime { get; set; }

        public ProjectDto? Project { get; set; } = null;
        
        public UserDto Producer { get; set; } = null!;
        
        public UserDto Executor { get; set; } = null!;
    }
}
