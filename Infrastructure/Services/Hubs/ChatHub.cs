using System.Transactions;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Services.Hubs
{
    public class ChatHub : Hub, IChatRoomsHandler
    {
        // [HubMethodName("SendMessage")]
        // public async Task SendMessage(string userName, string message)
        // {
        //     await Clients.All.SendAsync("receiveMessage", userName, message);
        // }

        public async Task SendMessage(string message)
        {
        }

        public Task AddToGroup(string groupName, string user)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFromGroup(string groupName, string user)
        {
            throw new NotImplementedException();
        }
    }
}