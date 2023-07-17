using DevExpress.Mvvm;
using JurChat.Client.Services.Interfaces;

namespace JurChat.Client.ViewModels.Pages
{
    internal class RegisterPageViewModel : BindableBase
    {
        private readonly IUserDialogService _userDialogService;

        public DelegateCommand ComeToLoginPageCommand => new(() => { _userDialogService.ShowLoginPage(); });

        public RegisterPageViewModel(IUserDialogService userDialogService) : this()
        {
            _userDialogService = userDialogService;
        }

        public RegisterPageViewModel() { }
    }
}
