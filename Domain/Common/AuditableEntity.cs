namespace Domain.Common;

public abstract class AuditableEntity
{
    public DateTime Created { get; set; }

    public string CreatedBy { get; set; }
}