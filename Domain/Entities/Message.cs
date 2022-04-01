namespace Domain.Entities;

public class Message : AuditableEntity
{
    public string Content { get; }

    public int Color { get; }


    public Message(string content, int color)
    {
        Content = content;
        Color = color;
    }
}
