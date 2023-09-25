using Presentation.App.Models;

namespace Presentation.App.Services.Interfaces
{
    public interface IApplicationSettingsService
    {
        public Settings? GetSettings();
        public void SetSetting(Settings settings);
    }
}
