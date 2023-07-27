using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace JurChat.Server
{
    class ConnectionManager
    {
        private readonly ConcurrentList<Task> _tasks;
        private readonly Room _room;
        private readonly CancellationTokenSource _cts;

        public ConnectionManager()
        {
            _tasks = new ConcurrentList<Task>();
            _room = new Room("Прихожая");
            _cts = new CancellationTokenSource();
        }

        public async Task RunConnectionAsync(HttpListenerContext context)
        {
            WebSocketConnection connection = new WebSocketConnection(context);
            Task task = RunAsync(connection, _cts.Token);
            _tasks.Add(task);
            _ = task.ContinueWith(_ => _tasks.Remove(task));
            await _room.EnterAsync(connection);
        }

        private async Task RunAsync(WebSocketConnection connection, CancellationToken token)
        {
            await connection.Run(token);
            _room.Leave(connection);
        }

        public async Task CloseAllAsync()
        {
            _cts.Cancel();
            await Task.WhenAll(_tasks.ToArray());
            _cts.Dispose();
        }
    }
}
