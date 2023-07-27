using System.Net;

namespace JurChat.Server
{
    class ChatServer
    {
        private readonly HttpListener _listener;
        private readonly ConnectionManager _manager;

        public ChatServer(int port)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add($"http://localhost:{port}/ws/");
            _listener.AuthenticationSchemes = AuthenticationSchemes.Basic;
            _manager = new ConnectionManager();
        }

        public async Task ListenAsync()
        {
            try
            {
                _listener.Start();
                Console.WriteLine("Сервер стартовал на " + _listener.Prefixes.First());
                while (true)
                {
                    HttpListenerContext context = await _listener.GetContextAsync();
                    if (context.Request.IsWebSocketRequest)
                    {
                        Console.WriteLine("HTTP Подключение: " + context.Request.RemoteEndPoint + " > " + context.Request.LocalEndPoint);
                        context.Response.StatusCode = (int)HttpStatusCode.NoContent;
                        await _manager.RunConnectionAsync(context);
                    }
                    else
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                        context.Response.Close();
                    }
                }
            }
            catch (HttpListenerException ex)
            {
                if (ex.ErrorCode == 995)
                    Console.WriteLine("Сервер остановлен.");
                else
                    throw ex;
            }
        }

        public async Task StopAsync()
        {
            if (_listener.IsListening)
            {
                Console.WriteLine("Отключаю подключенных клиентов...");
                await _manager.CloseAllAsync();
                Console.WriteLine("Клиенты отключены.");
                _listener.Stop();
            }
        }
    }
}
