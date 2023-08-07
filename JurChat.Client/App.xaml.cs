using System;
using System.Windows;
using JurChat.Client.Infrastructure.EntityFramework;
using JurChat.Presentation.App.Services.Implementations;
using JurChat.Presentation.App.Services.Interfaces;
using JurChat.Presentation.App.ViewModels.Pages;
using JurChat.Presentation.App.ViewModels.Windows;
using JurChat.Presentation.App.Views.Pages;
using JurChat.Presentation.App.Views.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace JurChat.Presentation.App
{
    public partial class App
    {
        public IServiceProvider _services;
        public IServiceProvider Services => _services ??= InitializeServices().BuildServiceProvider();

        public IServiceCollection InitializeServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainPageViewModel>();
            services.AddSingleton<SettingsPageViewModel>();
            services.AddSingleton<RegisterPageViewModel>();

            services.AddDbContext<DatabaseContext>();

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
