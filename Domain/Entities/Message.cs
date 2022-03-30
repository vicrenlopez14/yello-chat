namespace Domain.Entities;

public class Message : AuditableEntity
{
    public string Content { get; set; }

    public int Color { get; set; }
}