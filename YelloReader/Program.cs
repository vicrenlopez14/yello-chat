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
        // RODRIGO-MADE

        // Room data input
        Console.Write("Ingrese el nombre de la sala a la que quiere unirse (\"general\" por defecto): ");
        string roomName = Console.ReadLine() ?? "general";

        var messager = new ConnectionHubMessager();

        await messager.JoinToRoom("reader", roomName);

        Console.WriteLine("Conectado. Pulse enter para salir.");
        messager.Connection.On(MessageMethod.RECEIVE_MESSAGE,
            (string message) =>
            {
                // SUSAN MADE
                var deserializedMessage = JsonSerializer.Deserialize<Message>(message);

                Console.ForegroundColor = ColorMappings.CodeToConsole[deserializedMessage!.Color];

                Console.WriteLine(deserializedMessage.Created.ToString("hh:mm tt") + "~ " +
                                  deserializedMessage.CreatedBy + ":" + " " + deserializedMessage.Content);
            });

        Console.ReadKey();
    }
}