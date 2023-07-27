using System.Buffers.Binary;
using System.Net.Sockets;
using System.Text;
using System.Threading.Channels;
using JurChat.Network.Models;
using Newtonsoft.Json;

namespace JurChat.Network.Implementations
{
    public class Connection : IConnection
    {
        public event EventHandler<PackageMessage>? MessageReceived;

        public TcpClient TcpClient;

        private NetworkStream _stream;

        private Task _readingTask;

        private Task _writingTask;

        private Channel<string> _channel;

        private readonly Action _disposeCallback;

        private bool _disposed;

        private bool _isConnected;
        public bool IsConnected { get => _isConnected; }

        private async Task RunReadingLoop()
        {
            try
            {
                byte[] headerBuffer = new byte[4];

                while (true)
                {
                    int bytesReceived = await _stream.ReadAsync(headerBuffer, 0, headerBuffer.Length);

                    if (bytesReceived != 4) break;

                    int length = BinaryPrimitives.ReadInt32LittleEndian(headerBuffer);

                    byte[] buffer = new byte[length];

                    int count = 0;

                    while (count < length)
                    {
                        bytesReceived = await _stream.ReadAsync(buffer, count, buffer.Length - count);
                        count += bytesReceived;
                    }

                    MessageReceived?.Invoke(this, JsonConvert.DeserializeObject<PackageMessage>(Encoding.UTF8.GetString(buffer))!);
                }

                _stream.Close();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Подключение к {TcpClient.Client.AddressFamily} закрыто сервером.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            }
            if (!_disposed)
                _disposeCallback();
        }

        public async Task SendMessageAsync(PackageMessage message)
        {
            if (!_isConnected) throw new Exception("No connection.");

            await _channel.Writer.WriteAsync(JsonConvert.SerializeObject(message));
        }

        private async Task RunWritingLoop()
        {
            byte[] lengthMessage = new byte[4];

            await foreach (string message in _channel.Reader.ReadAllAsync())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(message);

                BinaryPrimitives.WriteInt32LittleEndian(lengthMessage, buffer.Length);

                await _stream.WriteAsync(lengthMessage, 0, lengthMessage.Length);

                await _stream.WriteAsync(buffer, 0, buffer.Length);
            }
        }

        public void Connect(string ip, int port)
        {
            throw new NotImplementedException();
        }

        public void Disconnect()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().FullName);

            _disposed = true;

            if (TcpClient.Connected)
            {
                _channel.Writer.Complete();
                _stream.Close();
                Task.WaitAll(_readingTask, _writingTask);
            }
            if (disposing)
            {
                TcpClient.Dispose();
            }
        }

        ~Connection() => Dispose(false);
    }
}
