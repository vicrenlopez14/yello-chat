using System.Text.Json;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR.Client;

namespace Infrastructure.Services.Hubs;

public class ConnectionHubMessager : IConnectionProvider
{
    public HubConnection Hub { get; set; }

    public ConnectionHubMessager()
    {
        Hub = new HubConnectionBuilder().WithUrl($"http://localhost:5000/{ServerRoutes.CHAT_ROOMS}")
            .Build();
        
        EstablishConnection();
    }


    // Gets a HubConnection used to be in communication with the server
    private void EstablishConnection()
    {
        Hub.StartAsync();
    }

    // Template for invoking a method and attaching a message
    private Task Invoke(string methodName, string arg)
    {
        return Hub.InvokeCoreAsync(methodName, new object[] {arg});
    }

    // Sends a message through a HubConnection
    public Task SendMessage(Message message)
    {
        var serialized = JsonSerializer.Serialize(message);

        return Invoke(MessageMethod.SEND_MESSAGE, serialized);
    }

    // Joins a user to a room
    public Task JoinToRoom(string username, string roomName)
    {
        return Hub.InvokeCoreAsync(MessageMethod.JOIN_TO_ROOM, new object[] {roomName, username});
    }

    // Exits a user from a room
    public Task ExitRoom(string username, string roomName)
    {
        return Hub.InvokeCoreAsync(MessageMethod.REMOVE_FROM_ROOM, new object[] {roomName, username});
    }
}