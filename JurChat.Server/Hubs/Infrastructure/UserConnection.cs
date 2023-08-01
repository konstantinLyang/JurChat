namespace JurChat.Server.Hubs.Infrastructure
{
    public class UserConnection
    {
        public UserConnection(string id)
        {
            Id = id;
            _connections = new();
        }

        public string Id { get; set; }

        public DateTime ConnectedAt
        {
            get
            {
                if (Connections.Any())
                {
                    return Connections
                        .OrderByDescending(x => x.ConnectedAt)
                        .Select(x => x.ConnectedAt)
                        .First();
                }

                return new DateTime();
            }
        }

        private readonly List<ChatConnection> _connections;
        public IEnumerable<ChatConnection> Connections => _connections;

        public void AppendConnection(string connectionId)
        {
            if (string.IsNullOrEmpty(connectionId)) throw new ArgumentNullException(nameof(connectionId));

            _connections.Add(new()
            {
                ConnectionId = connectionId,
                ConnectedAt = DateTime.Now,
            });
        }
        public void RemoveConnection(string connectionId)
        {
            if (string.IsNullOrEmpty(connectionId)) throw new ArgumentNullException(nameof(connectionId));

            var connection = _connections.FirstOrDefault(x => x.ConnectionId == connectionId);

            if (connection == null) return;

            _connections.Remove(connection);
        }
    }
}
