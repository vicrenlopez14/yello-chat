using System.Text.Json;
using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Services.Common;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Services.Hubs
{
    public class ChatHub : Hub, IChatRoomsHandler
    {
        private static JsonMessageSerializer serializer = new();

        [HubMethodName("SendMessage")]
        public async Task SendMessage(string message)
        {
            // Serialize to extract group name
            var deserialized = serializer.Deserialize(message);
            string roomName = deserialized?.Room ?? "general";

            await Clients.Group(roomName).SendAsync(MessageMethod.RECEIVE_MESSAGE, message);
        }

        [HubMethodName("JoinToRoom")]
        public async Task AddToRoom(string groupName, string userName)
        {
            Console.WriteLine($"JOIN TO GROUP {groupName}");
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            var newMessage = new Message($"{userName} has joined the room.", 11, groupName, DateTimeService.Now,
                ">>>YELLO-ADMIN<<<");

            await Clients.Group(groupName).SendAsync(MessageMethod.RECEIVE_MESSAGE, newMessage);
        }

        [HubMethodName("RemoveFromRoom")]
        public async Task RemoveFromRoom(string groupName, string userName)
        {
            Console.WriteLine("EXIT FROM GROUP");

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            var newMessage = new Message($"{userName} has left the room.", 11, groupName, DateTimeService.Now,
                ">>>YELLO-ADMIN<<<");

            await Clients.Group(groupName).SendAsync(MessageMethod.RECEIVE_MESSAGE, newMessage);
        }
    }
}