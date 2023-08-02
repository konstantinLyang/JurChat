using DevExpress.Mvvm;
using JurChat.Client.Persistence;
using JurChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using DelegateCommand = DevExpress.Mvvm.DelegateCommand;

namespace JurChat.Client.ViewModels.Pages
{
    public class MainPageViewModel : BindableBase
    { 

        public MainPageViewModel(ApplicationDbContext dbContext, IClientService clientService)
        {
            _context = dbContext;
            _clientService = clientService;
        }

        private readonly ApplicationDbContext _context;
        private readonly IClientService _clientService;

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
            }
        }

        #endregion

        private void OnReceivedMessage(object? sender, string message)
        {
            ReceivedText += message + "\n";
        }
    }
}
