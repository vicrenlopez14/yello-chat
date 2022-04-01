using System.Text.Json;
using Domain.Entities;
using Microsoft.AspNetCore.SignalR.Client;

namespace YelloWriter;

class Program
{
    public static void Main(string[] args)
    {
        var connection = new HubConnectionBuilder().WithUrl("http://localhost:5001/chathub").Build();


        var newMessage = new Message("Helouda", 2, "sds234", DateTime.Now, "vicrenlopez");
        var serialized = JsonSerializer.Serialize(newMessage);

        connection.StartAsync().Wait();
        connection.InvokeCoreAsync("SendMessage", new object[] {serialized});
        connection.On("ReceiveMessage",
            (string userName, string message) => { Console.WriteLine(userName + ':' + message); });

        Console.ReadKey();
    }
}