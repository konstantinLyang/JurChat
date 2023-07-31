using System;
using System.Windows;
using System.Windows.Controls;

namespace JurChat.Client.Views.Pages
{
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            MainGrid.ColumnDefinitions[1].MinWidth = 250;
        }

        private void ScrollViewer_OnScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (e.OriginalSource is ScrollViewer scrollViewer &&
                Math.Abs(e.ExtentHeightChange) > 0.0)
            {
                scrollViewer.ScrollToBottom();
            }
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 600)
            {
                MainGrid.ColumnDefinitions[1].MinWidth = 0;
                MainGrid.ColumnDefinitions[1].MaxWidth = 0;
                RightGrid.Visibility = Visibility.Collapsed;
            }
            else
            {
                MainGrid.ColumnDefinitions[1].MinWidth = 250;
                MainGrid.ColumnDefinitions[1].MaxWidth = 350;
                RightGrid.Visibility = Visibility.Visible;
            }
        }
    }
}
