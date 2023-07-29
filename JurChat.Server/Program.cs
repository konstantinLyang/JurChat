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



            Console.WriteLine($"{DateTime.Now:dd.MM.yyyy hh:mm:zzzz} конец работы сервера");
        }
    }
}

