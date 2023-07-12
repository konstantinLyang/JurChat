using DevExpress.Mvvm;
using JurChat.Client.Services.Interfaces;

namespace JurChat.Client.ViewModels.Pages
{
    internal class LoginPageViewModel : BindableBase
    {
        private readonly IUserDialogService _userDialogService;

        public string? Login { get; set; }
        public string? Password { get; set; }

        public DelegateCommand OpenRegisterWindowCommand => new(() => { _userDialogService.ShowRegisterPage(); });

        public LoginPageViewModel(IUserDialogService userDialogService)
        {
            _userDialogService = userDialogService;
        }
    }
}
