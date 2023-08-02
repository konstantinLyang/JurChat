using System;
using System.Windows;
using JurChat.Client.Services.Interfaces;
using JurChat.Client.ViewModels.Windows;
using JurChat.Client.Views.Pages;
using JurChat.Client.Views.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace JurChat.Client.Services.Implementations
{
    public class UserDialogService : IUserDialogService
    {
        private readonly IServiceProvider _serviceProvider;

        private MainWindow? _mainWindow;
        private MainWindowViewModel? _mainWindowViewModel;
        private MainPage? _mainPage;
        private LoginPage? _loginPage;
        private RegisterPage? _registerPage;

        public void StartApplication()
        {
            //TODO: закрытие проги, если уже открыта

            if (_mainWindow != null)
            {
                _mainWindow.Show();
                return;
            }

            _mainWindow = _serviceProvider.GetService<MainWindow>();
            
            _mainWindowViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();

            ShowLoginPage();

            _mainWindow.Show();
        }

        public void CloseApplication()
        {
            _mainWindow!.Close();
            Environment.Exit(0);
        }

        public void ShowLoginPage()
        {
            if (_loginPage != null)
            {
                _mainWindowViewModel.Page = _loginPage;
                return;
            }

            _loginPage = _serviceProvider.GetRequiredService<LoginPage>();

            _mainWindowViewModel.Page = _loginPage;
        }

        public void ShowRegisterPage()
        {
            if (_registerPage != null)
            {
                _mainWindowViewModel.Page = _registerPage;
                return;
            }

            _registerPage = _serviceProvider.GetRequiredService<RegisterPage>();

            _mainWindowViewModel.Page = _registerPage;
        }

        public void ShowMainPage()
        {
            if (_mainPage != null)
            {
                _mainWindowViewModel.Page = _mainPage;
                return;
            }

            _mainPage = _serviceProvider.GetRequiredService<MainPage>();

            _mainWindowViewModel.Page = _mainPage;
        }

        public void ShowSettingsPage()
        {
            _mainWindowViewModel!.SettingsPageVisibility = Visibility.Visible;
        }


        public UserDialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
    }
}
