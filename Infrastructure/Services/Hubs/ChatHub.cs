using Microsoft.AspNetCore.SignalR;

namespace Infrastructure.Services.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string userName, string message)
        {
            await Clients.All.SendAsync("receiveMessage", userName, message);
        }
        
    }
}