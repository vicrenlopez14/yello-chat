using Domain.Entities;
using Infrastructure.Services.Hubs;

namespace YelloWriter;

class Program
{
    public static void Main(string[] args)
    {
        var messager = new ConnectionHubMessager();

        messager.JoinToRoom("vicrenlopez", "cuarto");
        
        bool exit = false;
        while (exit == false)
        {
            messager.SendMessage(new Message("ola k ase", 2, "cuarto", DateTime.Now, "vicrenlopez"));
            Console.WriteLine("Mensaje enviado");

            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.A)
            {
                exit = true;
            }
        }

        messager.ExitRoom("vicrenlopez", "cuarto");

        Console.ReadKey();
    }
}