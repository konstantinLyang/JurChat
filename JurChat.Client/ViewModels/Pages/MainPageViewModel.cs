using DevExpress.Mvvm;
using Microsoft.AspNetCore.SignalR.Client;
using DelegateCommand = DevExpress.Mvvm.DelegateCommand;

namespace JurChat.Client.ViewModels.Pages
{
    public class MainPageViewModel : BindableBase
    { 
        public MainPageViewModel()
        {
            
        }

        private HubConnection _connection;
        public string MessageText { get; set; }
        public string ReceivedText { get; set; }

        #region Fields

        public string SearchBox { get; set; }

        #endregion

        #region Commands

        public DelegateCommand FindUserCommand;


        public DelegateCommand OpenRightPanelCommand;

        public DelegateCommand SendMessageCommand => new(OnSendMessage);
        private void OnSendMessage()
        {
            if (!string.IsNullOrEmpty(MessageText))
            {
                _connection.InvokeAsync("Send", MessageText);
            }
        }

        #endregion

        private void OnReceivedMessage(object? sender, string message)
        {
            ReceivedText += message + "\n";
        }
    }
}
