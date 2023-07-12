using System;
using System.Windows;
using JurChat.Client.Services.Implementations;
using JurChat.Client.Services.Interfaces;
using JurChat.Client.ViewModels.Pages;
using JurChat.Client.ViewModels.Windows;
using JurChat.Client.Views.Pages;
using JurChat.Client.Views.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace JurChat.Client
{
    public partial class App : Application
    {
        public IServiceProvider _services;
        public IServiceProvider Services => _services??= InitializeServices().BuildServiceProvider();

        public IServiceCollection InitializeServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainPageViewModel>();
            services.AddSingleton<SettingsPageViewModel>();

            services.AddTransient<LoginPageViewModel>();

            services.AddSingleton<IUserDialogService, UserDialogService>();

            services.AddTransient(s => new MainWindow() { DataContext = _services.GetRequiredService<MainWindowViewModel>() });
            services.AddTransient(s => new MainPage() { DataContext = _services.GetRequiredService<MainPageViewModel>() });
            services.AddTransient(s => new SettingsPage() { DataContext = _services.GetRequiredService<SettingsPageViewModel>() });
            services.AddTransient(s => new LoginPage() { DataContext = _services.GetRequiredService<LoginPageViewModel>() });
            services.AddTransient(s => new RegisterPage() { DataContext = new RegisterPageViewModel() });

            return services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Services.GetRequiredService<IUserDialogService>().StartApplication();
        }
    }
}
