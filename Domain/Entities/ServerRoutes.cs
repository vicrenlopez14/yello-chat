using System.Diagnostics;

namespace Domain.Entities;

public class ServerRoutes
{
    // ReSharper disable once InconsistentNaming
    public static readonly string SERVER_HOST =
        Debugger.IsAttached
            ? "http://localhost:80"
            : "https://yello-server.herokuapp.com";


    // ReSharper disable once InconsistentNaming
    public static readonly string CHAT_ROOMS = "chatrooms";
}