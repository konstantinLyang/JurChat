using DevExpress.Mvvm;
using DelegateCommand = DevExpress.Mvvm.DelegateCommand;

namespace JurChat.Client.ViewModels.Pages
{
    internal class MainPageViewModel : BindableBase
    {
        public double Width { get; set; }
        public double Height { get; set; }

        #region Fields

        public string SearchBox { get; set; }

        #endregion


        #region Commands

        public DelegateCommand FindUserCommand = new(() => {  });
        public DelegateCommand OpenRightPanelCommand = new(() => {  });

        #endregion

        public MainPageViewModel()
        {
            
        }
    }
}
