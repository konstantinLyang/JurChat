﻿namespace JurChat.Web.Hubs.Infrastructure
{
    public class ChatConnection
    {
        public DateTime ConnectedAt { get; set; }

        public string ConnectionId { get; set; } = null!;
    }
}
