using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using JurChat.Domain.Entities;
using JurChat.Presentation.App.Models;
using JurChat.Presentation.App.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;

namespace JurChat.Presentation.App.Services.Implementations
{
    public class ClientService : IClientService
    {
        public ClientService(IApplicationSettingsService applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        private AccessToken? _token;
        private string AccessToken => _token!.access_token;

        private readonly IApplicationSettingsService _applicationSettings;

        public HubConnection Connection { get; set; }

        public bool IsConnected { get; set; }
        public bool IsAuthorized { get; set; }

        public async Task<bool> Connect()
        {
            try
            {
                if (!IsConnected)
                {
                    var settings = _applicationSettings.GetSettings();

                    Connection = new HubConnectionBuilder()
                        .WithUrl($"https://{settings!.Address}:{settings.Port}/chat", options =>
                        {
                            options.AccessTokenProvider = () => Task.FromResult(AccessToken);
                        })
                        .Build();

                    await Connection.StartAsync();
                    IsConnected = true;
                    return true;
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Disconnect()
        {
            try
            {
                await Connection.StopAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Authorize(string login, string password)
        {
            var settings = _applicationSettings.GetSettings();

            HttpClient httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri($"https://{settings!.Address}:{settings.Port}");

            var response = await httpClient.PostAsJsonAsync($"https://{settings!.Address}:{settings.Port}/login", new User(){ Mail = login, Password = password});

            _token = JsonConvert.DeserializeObject<AccessToken>(response.Content.ReadAsStringAsync().Result);

            return _token != null;
        }
    }
}
