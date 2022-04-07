using System.Text.Json;
using Domain.Common;
using Domain.Entities;
using Infrastructure.Services.Hubs;
using Microsoft.AspNetCore.SignalR.Client;

namespace YelloReader;

class Program
{
    public static async Task Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("YelloReader");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(
            "Lector de mensajes de las salas de YelloChat, ingrese el nombre de la sala y podrá ver los mensajes. Asegúrese de hacer coincidir mayúsculas y minúsculas.\n");

        // RODRIGO-MADE

        // Room data input
        Console.Write("Ingrese el nombre de la sala a la que quiere unirse (\"general\" por defecto): ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        string roomName = Console.ReadLine() ?? "general";
        Console.ForegroundColor = ConsoleColor.White;


        var messager = new ConnectionHubMessager();

        await messager.JoinToRoom("reader", roomName);

        Console.WriteLine("Conectado. Pulse enter para salir.");
        try
        {
            messager.Hub.On(MessageMethod.RECEIVE_MESSAGE,
                (string message) =>
                {
                    // SUSAN MADE
                    var deserializedMessage = JsonSerializer.Deserialize<Message>(message);

                    Console.ForegroundColor = ColorMappings.CodeToConsole[deserializedMessage!.Color];

                    Console.WriteLine(deserializedMessage.Created.ToString("hh:mm tt") + "~ " +
                                      deserializedMessage.CreatedBy + ":" + " " + deserializedMessage.Content);
                });
        }
        catch
        {
            Console.WriteLine("No se ha podido establecer una conexión con el servidor, puede cerrar el programa.");
        }

        Console.ReadKey();
    }
}