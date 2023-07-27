using System.Text;

namespace JurChat.Server
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine($"{DateTime.Now:dd.MM.yyyy hh:mm:zzzz} запуск сервера");

            ChatServer server = new ChatServer(8080);
            Task servertask = server.ListenAsync();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "stop")
                {
                    Console.WriteLine("Остановка сервера...");
                    await server.StopAsync();
                    break;
                }
            }
            await servertask;

            Console.WriteLine($"{DateTime.Now:dd.MM.yyyy hh:mm:zzzz} конец работы сервера");
        }
    }
}

