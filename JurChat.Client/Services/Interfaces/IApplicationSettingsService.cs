using JurChat.Presentation.App.Models;

namespace JurChat.Presentation.App.Services.Interfaces
{
    public interface IApplicationSettingsService
    {
        public Settings? GetSettings();
        public void SetSetting(Settings settings);
    }
}
