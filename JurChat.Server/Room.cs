namespace JurChat.Server
{
    class Room
    {
        private readonly string _name;
        private readonly ConcurrentList<WebSocketConnection> _connections;
        private readonly ConcurrentList<Task> _readers;

        public Room(string name)
        {
            _connections = new ConcurrentList<WebSocketConnection>();
            _readers = new ConcurrentList<Task>();
            _name = name;
        }

        public async Task EnterAsync(WebSocketConnection connection)
        {
            await BroadcastMessageAsync($"{connection.User} вошел в чат {_name}");
            _connections.Add(connection);
            await connection.Writer.WriteAsync($"{connection.User}, добро пожаловать в чат {_name}");
            Task task = RunReaderAsync(connection);
            _readers.Add(task);
            _ = task.ContinueWith(_ => _readers.Remove(task));
        }

        private async Task RunReaderAsync(WebSocketConnection connection)
        {
            await foreach (string message in connection.Reader.ReadAllAsync())
            {
                string text = $"{connection.User}: {message}";
                await BroadcastMessageAsync(text);
                Console.WriteLine(text);
            }
        }

        private async Task BroadcastMessageAsync(string message)
        {
            foreach (WebSocketConnection connection in _connections)
            {
                await connection.Writer.WriteAsync(message);
            }
        }

        public void Leave(WebSocketConnection connection)
        {
            _connections.Remove(connection);
        }
    }
}
