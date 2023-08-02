using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using JurChat.Client.Models;
using JurChat.Client.Services.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;

namespace JurChat.Client.Services.Implementations
{
    public class ClientService : IClientService
    {
        public ClientService(IApplicationSettingsService applicationSettings)
        {
            _applicationSettings = applicationSettings;
        }

        private readonly IApplicationSettingsService _applicationSettings;

        public HubConnection Connection { get; set; }

        public async Task<bool> Connect()
        {
            try
            {
                var settings = _applicationSettings.GetSettings();

                Connection = new HubConnectionBuilder()
                    .WithUrl($"https://{settings!.Address}:{settings.Port}/chat")
                    .Build();

                await Connection.StartAsync();
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

        public async Task<bool> Authorized(string login, string password)
        {
            var settings = _applicationSettings.GetSettings();

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri($"https://{settings!.Address}:{settings.Port}/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync($"/api/User/{login}");

            if (response.StatusCode == HttpStatusCode.Found)
            {
                return true;
            }

            return false;
        }
    }
}
