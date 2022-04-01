namespace Domain.Common;

public abstract class AuditableEntity
{
    public DateTime Created { get; set; }

    public string CreatedBy { get; set; }

    public AuditableEntity()
    {
    }

    public AuditableEntity(DateTime created, string createdBy)
    {
        Created = created;
        CreatedBy = createdBy;
    }
}