namespace Domain.Entities;

public class Message : AuditableEntity
{
    public string Content { get; }

    public int Color { get; }

    public string Room { get; }

    public Message()
    {
    }

    public Message(string content, int color, string room)
    {
        Content = content;
        Color = color;
        Room = room;
    }

    public Message(string content, int color, string room, DateTime dateTime, string username) : base(dateTime,
        username)
    {
        Content = content;
        Color = color;
        Room = room;
    }
}