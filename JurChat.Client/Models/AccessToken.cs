using System;

namespace JurChat.Client.Models
{
    public class AccessToken
    {
        public string email { get; set; } = null!;
        public string access_token { get; set; } = null!;
    }
}
