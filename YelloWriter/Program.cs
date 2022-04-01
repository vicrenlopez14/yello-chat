using Microsoft.AspNetCore.SignalR.Client;

namespace YelloWriter;

class Program
{
    public static void Main(string[] args)
    {
        var connection = new HubConnectionBuilder().WithUrl("http://localhost:5001/chatHub").Build();

        connection.StartAsync().Wait();
        connection.InvokeCoreAsync("SendMessage", args: new[] {"vicrenlopez", "Hello"});
        connection.On("ReceiveMessage",
            (string userName, string message) => { Console.WriteLine(userName + ':' + message); });

        Console.ReadKey();
    }
}