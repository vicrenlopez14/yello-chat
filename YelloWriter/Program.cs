using System.Text.Json;
using Domain.Entities;
using Infrastructure.Services.Hubs;
using Microsoft.AspNetCore.SignalR.Client;

namespace YelloWriter;

class Program
{
    public static void Main(string[] args)
    {
        var connection = ConnectionHubProvider.EstablishConnection();
        var newMessage = new Message("Helouda", 2, "sds234", DateTime.Now, "vicrenlopez");
        ConnectionHubProvider.SendMessage(connection, newMessage);

        Console.ReadKey();
    }
}