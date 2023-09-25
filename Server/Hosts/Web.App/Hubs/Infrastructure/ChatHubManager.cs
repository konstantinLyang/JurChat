namespace Web.App.Hubs.Infrastructure
{
    public class  ChatHubManager
    {
        public List<UserConnection> ConnectedUsers { get; set; } = new();

        public bool ConnectUser(string userId, string connectionId)
        {
            try
            {
                var existsUser = GetConnectedUserById(userId);
                if (existsUser != null)
                {
                    existsUser.AppendConnection(connectionId);
                    return true;
                }

                UserConnection user = new(userId);
                user.AppendConnection(connectionId);
                ConnectedUsers.Add(user);
                return true;
            }
            catch (Exception ex) { return false; }
        }

        public bool DisconnectUser(string connectionId)
        {
            try
            {
                var user = GetConnectedUserByConnectionId(connectionId);

                if (user == null) return true;

                if (user.Connections.Count() == 1)
                {
                    user.RemoveConnection(user.Connections.Last().ConnectionId);
                    ConnectedUsers.Remove(user);
                    return true;
                }

                if (!user.Connections.Any())
                {
                    ConnectedUsers.Remove(user);
                    return true;
                }

                user.RemoveConnection(user.Connections.Last().ConnectionId);
                
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private UserConnection? GetConnectedUserById(string userId) =>
            ConnectedUsers.FirstOrDefault(x => x.Id == userId);

        private UserConnection? GetConnectedUserByConnectionId(string connectionId) =>
            ConnectedUsers.FirstOrDefault(x => x.Connections.Select(c => c.ConnectionId).Contains(connectionId));
    }
}
