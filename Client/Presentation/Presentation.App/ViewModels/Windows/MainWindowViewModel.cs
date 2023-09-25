using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Mvvm;
using Microsoft.Extensions.DependencyInjection;
using Presentation.App.Views.Pages;

namespace Presentation.App.ViewModels.Windows
{
    public class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            SettingsPage = _serviceProvider.GetRequiredService<SettingsPage>();
        }

        private readonly IServiceProvider _serviceProvider;

        public Page? Page { get; set; }
        public Page? SettingsPage { get; set; }
        public Visibility SettingsPageVisibility { get; set; } = Visibility.Collapsed;

        #region Commands

        public DelegateCommand CloseSettingsPage => new(() => { SettingsPageVisibility = Visibility.Collapsed; });

        #endregion
    }
}
