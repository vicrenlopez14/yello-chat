using System.Text.Json;
using Domain.Entities;
using Infrastructure.Services.Hubs;
using Microsoft.AspNetCore.SignalR.Client;

namespace YelloReader;

class Program
{
    public static void Main(string[] args)
    {
        var connection = ConnectionHubProvider.EstablishConnection();

        connection.On("ReceiveMessage",
            (string message) =>
            {
                var deserializedMessage = JsonSerializer.Deserialize<Message>(message);
                Console.WriteLine(deserializedMessage!.CreatedBy + ':' + deserializedMessage.Content);
            });
    }
}