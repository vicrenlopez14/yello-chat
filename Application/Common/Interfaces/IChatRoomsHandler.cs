namespace Application.Common.Interfaces;

public interface IChatRoomsHandler
{
    public Task SendMessage(string message);

    public Task AddToGroup(string groupName, string user);

    public Task RemoveFromGroup(string groupName, string user);
}