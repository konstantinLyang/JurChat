using System.Threading.Tasks;
using DevExpress.Mvvm;
using JurChat.Client.Services.Interfaces;

namespace JurChat.Client.ViewModels.Pages
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
            if (await _clientService.Connect())
            {
                if (await _clientService.Authorized(Login, Password))
                {
                    _userDialogService.ShowMainPage();
                }
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
