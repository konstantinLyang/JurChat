using System;
using System.Windows.Threading;
using DevExpress.Mvvm;
using JurChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using DelegateCommand = DevExpress.Mvvm.DelegateCommand;

namespace JurChat.Client.ViewModels.Pages
{
    public class MainPageViewModel : BindableBase
    {
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

        public MainPageViewModel()
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:7244/chat")
                .Build();

            _connection.On<string, string>("Receive", (user, message) =>
            {
                var newMessage = $"{user}: {message}";
                ReceivedText += newMessage;
            });
            _connection.StartAsync();
        }
    }
}
