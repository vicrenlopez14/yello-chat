using Application.Common.Interfaces;
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
            Console.WriteLine("SEND MESSAGE");

            // Serialize to extract group name
            var deserialized = new JsonMessageSerializer().Deserialize(message);

            Console.WriteLine("Message!");
            
            await Clients.Group(deserialized!.Room).SendAsync(MessageMethod.RECEIVE_MESSAGE, message);
        }

        [HubMethodName("JoinToRoom")]
        public async Task AddToRoom(string groupName, string userName)
        {
            Console.WriteLine("JOIN TO GROUP");
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