using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Services.Common;
using Microsoft.AspNetCore.SignalR;


namespace Infrastructure.Services.Hubs;

public class ChatHub : Hub, IChatRoomsHandler
{
    private static readonly List<Message> Messages = new();
    private static readonly JsonMessageSerializer Serializer = new();

    [HubMethodName("SendMessage")]
    public async Task SendMessage(string message)
    {
        // Serialize to extract group name
        var deserializedMessage = Serializer.Deserialize(message);
        string roomName = deserializedMessage?.Room ?? "general";

        // Preserve the message
        Messages.Add(deserializedMessage!);

        await Clients.Group(roomName).SendAsync(MessageMethod.RECEIVE_MESSAGE, message);
    }

    [HubMethodName("JoinToRoom")]
    public async Task AddToRoom(string groupName, string userName)
    {
        Console.WriteLine($"JOIN TO GROUP {groupName} by {userName}");
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

        // Create new warning message
        var newMessage = new Message($"{userName} has joined the room.", 11, groupName, DateTimeService.Now,
            ">>>YELLO-ADMIN<<<");

        // Resending order
        await ResendAllMessages(groupName);

        await Clients.Group(groupName).SendAsync(MessageMethod.RECEIVE_MESSAGE, newMessage);
    }

    [HubMethodName("RemoveFromRoom")]
    public async Task RemoveFromRoom(string groupName, string userName)
    {
        Console.WriteLine("EXIT FROM GROUP");

        // Remove from group
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

        var newMessage = new Message($"{userName} has left the room.", 11, groupName, DateTimeService.Now,
            ">>>YELLO-ADMIN<<<");

        await Clients.Group(groupName).SendAsync(MessageMethod.RECEIVE_MESSAGE, newMessage);
    }

    private async Task ResendAllMessages(String groupName)
    {
        // Getting the messages with the same group destination
        var missedMessages = from message in Messages
            where message.Room == groupName
            orderby message.Created
            select message;

        // Resending each message
        foreach (var message in missedMessages)
        {
            var serializedMessage = Serializer.Serialize(message);

            await Clients.Client(Context.ConnectionId).SendAsync(MessageMethod.RECEIVE_MESSAGE, serializedMessage);
        }
    }
}