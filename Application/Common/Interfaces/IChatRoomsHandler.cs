namespace Application.Common.Interfaces;

public interface IChatRoomsHandler
{
    public Task SendMessage(string message);

    public Task AddToRoom(string groupName, string user);

    public Task RemoveFromRoom(string groupName, string user);
}