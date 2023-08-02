using DevExpress.Mvvm;
using JurChat.Client.Models;
using JurChat.Client.Services.Interfaces;

namespace JurChat.Client.ViewModels.Pages
{
    public class SettingsPageViewModel : BindableBase
    {
        public SettingsPageViewModel(IApplicationSettingsService applicationSettingsService)
        {
            _applicationSettingsServices = applicationSettingsService;

            AppSettings = applicationSettingsService.GetSettings();
        }

        private readonly IApplicationSettingsService _applicationSettingsServices;
        
        public Settings AppSettings { get; set; }

        #region Commands

        public DelegateCommand ChangedSettings => new(OnChangedSettings);
        private void OnChangedSettings()
        {
            _applicationSettingsServices.SetSetting(AppSettings);
        }

        public DelegateCommand AboutApplicationCommand => new(OnAboutApplication);
        private void OnAboutApplication()
        {

        }

        #endregion
    }
}
