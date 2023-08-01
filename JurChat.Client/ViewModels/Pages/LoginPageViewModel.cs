using DevExpress.Mvvm;
using JurChat.Client.Persistence;
using JurChat.Client.Services.Interfaces;

namespace JurChat.Client.ViewModels.Pages
{
    public class LoginPageViewModel : BindableBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IUserDialogService _userDialogService;

        #region Fields

        public string Login { get; set; }
        public string Password { get; set; }
        public string Info { get; set; }
        public bool RememberUser { get; set; }

        #endregion

        #region Commands

        public DelegateCommand<object> AuthorizationCommand => new(OnAuthorization, CanAuthorizationCommand);
        private void OnAuthorization(object p)
        {
            _userDialogService.ShowMainPage();
        }
        private bool CanAuthorizationCommand(object p)
        {
            return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
        }

        public DelegateCommand OpenRegisterWindowCommand => new(() => { _userDialogService.ShowRegisterPage(); });

        #endregion

        public LoginPageViewModel(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;
            _dbContext = new ApplicationDbContext();
        }
    }
}
