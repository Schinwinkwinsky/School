namespace School.Domain.Entities;

public class EntityBase
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }

    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set; }
    public Guid DeletedBy { get; set; }

    public bool IsDeleted => DeletedAt != DateTime.MinValue;
}
