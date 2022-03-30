namespace Domain.Events;

public class NewMessageEvent : DomainEvent
{
    public NewMessageEvent(Message message)
    {
        NewMessage = message;
    }

    public Message NewMessage { get; }
}