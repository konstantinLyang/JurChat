using System.Threading.Tasks;
using DevExpress.Mvvm;
using Presentation.App.Services.Interfaces;

namespace Presentation.App.ViewModels.Pages
{
    public class LoginPageViewModel : BindableBase
    {
        public LoginPageViewModel(IUserDialogService userDialogService, IClientService clientService)
        {
            _userDialogService = userDialogService;
            _clientService = clientService;
        }
        
        private readonly IUserDialogService _userDialogService;
        private readonly IClientService _clientService;

        #region Fields

        public string Login { get; set; }
        public string Password { get; set; }
        public string Info { get; set; }
        public bool RememberUser { get; set; }

        #endregion

        #region Commands

        public AsyncCommand AuthorizationCommand => new(OnAuthorization, CanAuthorizationCommand);
        private async Task OnAuthorization()
        {
            if (await _clientService.Authorize(Login, Password))
            {
                if (await _clientService.Connect()) _userDialogService.ShowMainPage();
            }
        }
        private bool CanAuthorizationCommand()
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }

        public DelegateCommand OpenRegisterWindowCommand => new(() => { _userDialogService.ShowRegisterPage(); });
        public DelegateCommand ShowSettingsPageCommand => new(() => { _userDialogService.ShowSettingsPage(); });

        #endregion
    }
}
