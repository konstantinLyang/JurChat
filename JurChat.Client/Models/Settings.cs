namespace JurChat.Presentation.App.Models
{
    public class Settings
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? Port { get; set; }
        public bool StartOnWindows { get; set; }
        public bool TrayVisibility { get; set; }
    }
}
