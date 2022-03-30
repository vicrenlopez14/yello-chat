namespace Domain.Common;

public interface IHasDomainEvent
{
    public List<DomainEvent> DomainEvents { get; set; }
}

public abstract class DomainEvent
{
    protected DomainEvent()
    {
        DateOcurred = DateTimeOffset.Now;
    }

    public bool isPublished { get; set; }

    public DateTimeOffset DateOcurred { get; protected set; } = DateTime.Now;
}