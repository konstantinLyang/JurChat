using System;
using System.Windows;
using JurChat.Client.Persistence;
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
            services.AddSingleton<RegisterPageViewModel>();

            services.AddDbContext<ApplicationDbContext>();

            services.AddTransient<LoginPageViewModel>();

            services.AddSingleton<IUserDialogService, UserDialogService>();
            services.AddSingleton<IClientService, ClientService>();
            services.AddSingleton<IApplicationSettingsService, ApplicationSettingsService>();

            services.AddSingleton(s => new MainWindow() { DataContext = _services.GetRequiredService<MainWindowViewModel>() });
            services.AddSingleton(s => new MainPage() { DataContext = _services.GetRequiredService<MainPageViewModel>() });
            services.AddSingleton(s => new SettingsPage() { DataContext = _services.GetRequiredService<SettingsPageViewModel>() });
            services.AddSingleton(s => new LoginPage() { DataContext = _services.GetRequiredService<LoginPageViewModel>() });
            services.AddSingleton(s => new RegisterPage() { DataContext = _services.GetRequiredService<RegisterPageViewModel>() });

            return services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Services.GetRequiredService<IUserDialogService>().StartApplication();
        }
    }
}
