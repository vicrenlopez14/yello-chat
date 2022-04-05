using Domain.Entities;

namespace Application.Common.Interfaces;

public interface IConnectionProvider
{
    public Task SendMessage(Message message);

    public Task JoinToRoom(string username, string roomName);

    public Task ExitRoom(string username, string roomName);
}