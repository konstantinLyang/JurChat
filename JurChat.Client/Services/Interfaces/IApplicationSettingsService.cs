using JurChat.Client.Models;

namespace JurChat.Client.Services.Interfaces
{
    public interface IApplicationSettingsService
    {
        public Settings? GetSettings();
        public void SetSetting(Settings settings);
    }
}
