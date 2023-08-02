using System;
using System.IO;
using JurChat.Client.Models;
using JurChat.Client.Services.Interfaces;
using Newtonsoft.Json;

namespace JurChat.Client.Services.Implementations
{
    public class ApplicationSettingsService : IApplicationSettingsService
    {
        public ApplicationSettingsService()
        {
            if (!File.Exists(AppDataFilePath))
            {
                SetDefaultSettings();
            }
        }

        private static readonly string AppDataFilePath =
            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "jurchat.json");

        public Settings? GetSettings()
        {
            try
            {
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(AppDataFilePath));
            }
            catch
            {
                SetDefaultSettings();
                return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(AppDataFilePath));
            }
        }

        public void SetSetting(Settings settings) =>
            File.WriteAllText(AppDataFilePath, JsonConvert.SerializeObject(settings));

        private void SetDefaultSettings()
        {
            try { File.Delete(AppDataFilePath); } catch { /* ignored */}
            File.Create(AppDataFilePath).Close();
            File.WriteAllText(AppDataFilePath, JsonConvert.SerializeObject(new Settings()
            {
                Address = "localhost",
                Port = "7244",
                StartOnWindows = true,
                TrayVisibility = true
            }));
        }
    }
}
