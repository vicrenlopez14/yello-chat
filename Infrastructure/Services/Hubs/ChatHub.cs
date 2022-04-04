﻿using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Services.Common;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Services.Hubs
{
    public class ChatHub : Hub, IChatRoomsHandler
    {
        [HubMethodName("SendMessage")]
        public async Task SendMessage(string message)
        {
            // Serialize to extract group name
            var deserialized = new JsonMessageSerializer().Deserialize(message);

            await Clients.Group(deserialized!.Room).SendAsync("ReceiveMessage", message);
        }

        [HubMethodName("JoinToRoom")]
        public async Task AddToRoom(string groupName, string userName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);

            var newMessage = new Message($"{userName} has joined the room.", 11, groupName, DateTimeService.Now,
                ">>>YELLO-ADMIN<<<");

            await Clients.Group(groupName).SendAsync("ReceiveMessage", newMessage);
        }

        [HubMethodName("RemoveFromRoom")]
        public async Task RemoveFromRoom(string groupName, string userName)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);

            var newMessage = new Message($"{userName} has left the room.", 11, groupName, DateTimeService.Now,
                ">>>YELLO-ADMIN<<<");

            await Clients.Group(groupName).SendAsync("ReceiveMessage", newMessage);
        }
    }
}