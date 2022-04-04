using System.Text.Json;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR.Client;

namespace Infrastructure.Services.Hubs;

public class ConnectionHubProvider
{
    // Gets a HubConnection used to be in communication with the server
    public static HubConnection EstablishConnection()
    {
        return new HubConnectionBuilder().WithUrl($"http://localhost:5001/{ServerRoutes.CHAT_ROOMS}")
            .Build();
    }

    // Sends a message through a HubConnection
    public static void SendMessage(HubConnection connection, Message message)
    {
        connection.StartAsync().Wait();
        connection.InvokeCoreAsync("SendMessage", new object[] {JsonSerializer.Serialize(message)});
    }
}