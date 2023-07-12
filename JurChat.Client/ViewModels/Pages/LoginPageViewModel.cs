using DevExpress.Mvvm;

namespace JurChat.Client.ViewModels.Pages
{
    internal class LoginPageViewModel : BindableBase
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public LoginPageViewModel()
        {
            
        }
    }
}
