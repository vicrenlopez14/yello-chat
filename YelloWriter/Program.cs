using Domain.Common;
using Domain.Entities;
using Infrastructure.Services.Hubs;
using RandomNameGenerator;

namespace YelloWriter;

class Program
{
    public static void Main(string[] args)
    {
        var messager = new ConnectionHubMessager();

        // RODRIGO-MADE

        // Room data input
        Console.Write("Ingrese el nombre de la sala a la que quiere unirse (\"general\" por defecto): ");
        string roomName = Console.ReadLine() ?? "general";

        // User data input
        (string username, ConsoleColor color) = GetUsernameAndColor();

        // Init join request
        messager.JoinToRoom(username, roomName);

        // Messaging stage
        MessageStage(messager, color, username, roomName);
    }

    private static async void MessageStage(ConnectionHubMessager messager, ConsoleColor desiredcolor, string username,
        string roomName)
    {
        string message;

        Console.WriteLine("Para salir del programa escribe la letra \"x\" y envía...");

        while (true)
        {
            Console.Clear();
            write_it:
            // Typing the message
            Console.Write("Escriba su mensaje: ");
            message = Console.ReadLine();

            // Exit verification
            if (message == "x")
            {
                await messager.ExitRoom(username, roomName);
                Environment.Exit(0);
            }

            if (message == "")
            {
                Console.WriteLine("Por favor escribe un mensaje no vacío.");
                goto write_it;
            }

            // Message object creation
            var newMessage = new Message(message!, ColorMappings.ConsoleToCode[desiredcolor], roomName, DateTime.Now,
                username);

            // Message sending
            messager.SendMessage(newMessage);
        }
        // ReSharper disable once FunctionNeverReturns
    }

    // REBECA-MADE
    static (String, ConsoleColor) GetUsernameAndColor()
    {
        // Username input
        Console.Write("Ingrese el nombre de usuario con el que desea identificarse: ");
        string user = Console.ReadLine() ?? NameGenerator.Generate(Gender.Male);

        Console.Write("Su nombre de usuario es: " + user);

        // Color input
        Console.WriteLine("Elija una opción para el color de sus mensajes: ");
        Console.WriteLine("1. Color azul ");
        Console.WriteLine("2. Cyan ");
        Console.WriteLine("3. Color azul marino.");
        Console.WriteLine("4. Color verde azulado ");
        Console.WriteLine("5. Color verde oscuro. ");
        Console.WriteLine("6. Color fucsia oscuro ");
        Console.WriteLine("7. Color rojo oscuro. ");
        Console.WriteLine("8. Color amarillo oscuro ");
        Console.WriteLine("9. Color verde. ");
        Console.WriteLine("10. Color fucsia ");
        Console.WriteLine("11. Color rojo. ");
        Console.WriteLine("12. Color blanco");
        Console.WriteLine("13. Color amarillo. ");

        color_input:
        Console.Write("Opción: ");

        int color = int.Parse(Console.ReadLine() ?? "1");

        if (!(color is >= 1 and <= 13))
        {
            Console.WriteLine("Color inválido, intente de nuevo.");
            goto color_input;
        }

        return (user, ColorMappings.CodeToConsole[color]);
    }
}