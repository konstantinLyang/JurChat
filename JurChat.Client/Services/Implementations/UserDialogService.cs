using System;
using System.Diagnostics;
using System.IO;
using JurChat.Client.Services.Interfaces;
using JurChat.Client.ViewModels.Windows;
using JurChat.Client.Views.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace JurChat.Client.Services.Implementations
{
    internal class UserDialogService : IUserDialogService
    {
        private readonly IServiceProvider _serviceProvider;

        private MainWindow? _mainWindow;
        private MainWindowViewModel _mainWindowViewModel;

        private MainPage? _mainPage;
        private LoginPage? _loginPage;
        private RegisterPage? _registerPage;
        private SettingsPage? _settingsPage;

        public UserDialogService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void StartApplication()
        {
            Process[] processesList =
                Process.GetProcessesByName(
                    new FileInfo(Process.GetCurrentProcess().MainModule?.FileName!).Name.Replace(".exe", ""));

            if (processesList.Length > 1) CloseApplication();

            if (_mainWindow is { } window)
            {
                window.Show();
                return;
            }

            window = _serviceProvider.GetService<MainWindow>();
            
            _mainWindowViewModel = _serviceProvider.GetRequiredService<MainWindowViewModel>();

            _mainWindow = window;

            ShowLoginPage();

            window.Show();
        }

        public void CloseApplication()
        {
            _mainWindow!.Close();
            Environment.Exit(0);
        }

        public void ShowLoginPage()
        {
            if (_loginPage is { } page)
            {
                _mainWindowViewModel.Page = page;
                return;
            }

            page = _serviceProvider.GetRequiredService<LoginPage>();

            _mainWindowViewModel.Page = page;

            _loginPage = page;
        }

        public void ShowRegisterPage()
        {
            if (_registerPage is { } page)
            {
                _mainWindowViewModel.Page = page;
                return;
            }

            page = _serviceProvider.GetRequiredService<RegisterPage>();

            _mainWindowViewModel.Page = page;

            _registerPage = page;
        }

        public void ShowMainPage()
        {
            if (_mainPage is { } page)
            {
                _mainWindowViewModel.Page = page;
                return;
            }

            page = _serviceProvider.GetRequiredService<MainPage>();

            _mainWindowViewModel.Page = page;

            _mainPage = page;
        }

        public void ShowSettingsPage()
        {
            if (_settingsPage is { } page)
            {
                _mainWindowViewModel.Page = page;
                return;
            }

            page = _serviceProvider.GetRequiredService<SettingsPage>();

            _mainWindowViewModel.Page = page;

            _settingsPage = page;
        }
    }
}
