using Domain.Common;
using Domain.Entities;
using Infrastructure.Services.Hubs;
using RandomNameGenerator;

namespace YelloWriter;

class Program
{
    public static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("YelloWriter");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Ingrese el nombre de la sala, un nombre de usuario para identificarse y un color para distinguirse.\n");
        
        var messager = new ConnectionHubMessager();

        // RODRIGO-MADE

        // Room data input
        Console.Write("Ingrese el nombre de la sala a la que quiere unirse (\"general\" por defecto): ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string roomName = Console.ReadLine() ?? "general";
        Console.ForegroundColor = ConsoleColor.White;

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
        int color = 1;

        // Username input
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("Ingrese el nombre de usuario con el que desea identificarse: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string user = Console.ReadLine() ?? NameGenerator.Generate(Gender.Male);
        Console.ForegroundColor = ConsoleColor.White;

        if (user.Length == 0)
        {
            user = NameGenerator.Generate(Gender.Female);
        }

        Console.WriteLine("Su nombre de usuario es: " + user);

        // Color input
        Console.WriteLine("Elija una opción para el color de sus mensajes: ");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("1. Color azul ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("2. Cyan ");
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("3. Color azul marino.");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("4. Color verde azulado ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine("5. Color verde oscuro. ");
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("6. Color fucsia oscuro ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("7. Color rojo oscuro. ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("8. Color amarillo oscuro ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("9. Color verde. ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("10. Color fucsia ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("11. Color rojo. ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("12. Color blanco");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("13. Color amarillo. ");
        Console.ForegroundColor = ConsoleColor.White;

        color_input:
        Console.Write("Opción: ");
        
        // Handle parse type exceptions
        try
        {
            color = int.Parse(Console.ReadLine() ?? "1");
        }
        catch
        {
            Console.WriteLine("Por favor escribe un número válido.");
            goto color_input;
        }

        // Verify the color is valid
        if (!(color is >= 1 and <= 13))
        {
            Console.WriteLine("Color inválido, intente de nuevo.");
            goto color_input;
        }

        // Map the color code to ConsoleColor object
        return (user, ColorMappings.CodeToConsole[color]);
    }
}