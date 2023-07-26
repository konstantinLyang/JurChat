using System.Windows;
using DevExpress.Mvvm;
using HandyControl.Tools.Command;
using DelegateCommand = DevExpress.Mvvm.DelegateCommand;

namespace JurChat.Client.ViewModels.Pages
{
    internal class MainPageViewModel : BindableBase
    {
        public string MessageText { get; set; }
        public double RightPanelMinWidth { get; set; }

        #region Fields

        public string SearchBox { get; set; }

        #endregion

        #region Commands

        public DelegateCommand FindUserCommand;

        public DelegateCommand OpenRightPanelCommand;

        public DelegateCommand SendMessageCommand => new(OnSendMessage);
        private void OnSendMessage()
        {

        }

        #endregion

        public MainPageViewModel()
        {
            
        }
    }
}
