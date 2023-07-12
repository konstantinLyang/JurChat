namespace JurChat.Client.Services.Interfaces
{
    internal interface IUserDialogService
    {
        public void StartApplication();
        public void CloseApplication();
        public void ShowLoginPage();
        public void ShowRegisterPage();
        public void ShowMainPage();
        public void ShowSettingsPage();
    }
}
