using DevExpress.Mvvm;
using Presentation.App.Services.Interfaces;
using DelegateCommand = DevExpress.Mvvm.DelegateCommand;

namespace Presentation.App.ViewModels.Pages
{
    public class MainPageViewModel : BindableBase
    { 
        public MainPageViewModel(IClientService clientService)
        {
            _clientService = clientService;
        }
        
        private readonly IClientService _clientService;

        public string MessageText { get; set; } = "";
        public string ReceivedText { get; set; } = "";

        #region Fields

        public string SearchBox { get; set; } = "";

        #endregion

        #region Commands
        
        public DelegateCommand SendMessageCommand => new(OnSendMessage);
        private void OnSendMessage()
        {
            if (!string.IsNullOrEmpty(MessageText))
            {
            }
        }

        #endregion

        private void OnReceivedMessage(object? sender, string message)
        {
            ReceivedText += message + "\n";
        }
    }
}
