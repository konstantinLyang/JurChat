namespace Web.App.Models
{
    public class MessageFileModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = null!;
        
        public string ServerFilePath { get; set; } = null!;

        public bool IsImage { get; set; }
    }
}
