using System.Net;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Channels;
using System.Web;

namespace JurChat.Server
{
    class WebSocketConnection
    {
        private readonly HttpListenerContext _context;
        private readonly Channel<string> _sendChannel;
        private readonly Channel<string> _receiveChannel;
        private HttpListenerBasicIdentity _identity;

        public string User => HttpUtility.UrlDecode(_identity.Name);
        public ChannelWriter<string> Writer => _sendChannel.Writer;
        public ChannelReader<string> Reader => _receiveChannel.Reader;

        public WebSocketConnection(HttpListenerContext context)
        {
            _context = context;
            _sendChannel = Channel.CreateUnbounded<string>();
            _receiveChannel = Channel.CreateUnbounded<string>();
        }

        public async Task Run(CancellationToken token)
        {
            try
            {
                using CancellationTokenRegistration registration = token.Register(() => CompleteChannels());
                WebSocketContext wsContext = await _context.AcceptWebSocketAsync(null);
                _identity = (HttpListenerBasicIdentity)wsContext.User.Identity;
                Console.WriteLine($"WebSocket подключение: {_context.Request.RemoteEndPoint}");
                WebSocket ws = wsContext.WebSocket;
                Task readerTask = ReceiveAsync(ws);
                await foreach (string message in _sendChannel.Reader.ReadAllAsync())
                {
                    await ws.SendAsync(Encoding.UTF8.GetBytes(message), WebSocketMessageType.Text, true, CancellationToken.None);
                }
                if (ws.State == WebSocketState.Open)
                {
                    Console.WriteLine($"Закрываю WebSocket: {_context.Request.RemoteEndPoint}");
                    await ws.CloseAsync(WebSocketCloseStatus.EndpointUnavailable, string.Empty, CancellationToken.None);
                }
                await readerTask;
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.GetType().Name}: {ex.Message}");
                _context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            _context.Response.Close();
            Console.WriteLine($"Соединение закрыто: {_context.Request.RemoteEndPoint}");

        }

        private void CompleteChannels()
        {
            _receiveChannel.Writer.Complete();
            _sendChannel.Writer.Complete();
        }

        private async Task ReceiveAsync(WebSocket ws)
        {
            Memory<byte> buffer = new byte[1024];
            List<byte> data = new List<byte>();
            while (ws.State == WebSocketState.Open)
            {
                ValueWebSocketReceiveResult wsResult = await ws.ReceiveAsync(buffer, CancellationToken.None);
                switch (wsResult.MessageType)
                {
                    case WebSocketMessageType.Close when ws.State == WebSocketState.CloseReceived:
                        await ws.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                        Console.WriteLine($"WebSocket закрыт клиентом: {_context.Request.RemoteEndPoint}");
                        CompleteChannels();
                        break;
                    case WebSocketMessageType.Close:
                        Console.WriteLine($"WebSocket закрыт сервером: {_context.Request.RemoteEndPoint}");
                        break;
                    case WebSocketMessageType.Text:
                        data.AddRange(buffer[..wsResult.Count].ToArray());
                        if (wsResult.EndOfMessage)
                        {
                            await _receiveChannel.Writer.WriteAsync(Encoding.UTF8.GetString(data.ToArray()));
                            data.Clear();
                        }
                        break;
                    default:
                        Console.WriteLine($"Неподдерживаемый пакет от {_context.Request.RemoteEndPoint}: State = {ws.State}, WebSocketMessageType = {wsResult.MessageType}, Count = {wsResult.Count}, EndOfMessage = {wsResult.EndOfMessage}");
                        break;
                }
            }
        }
    }
}
