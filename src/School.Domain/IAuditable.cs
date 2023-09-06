namespace School.Domain;

public interface IAuditable
{
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public DateTime DeletedAt { get; set; }

    public Guid CreatedBy { get; set; }
    public Guid UpdatedBy { get; set; }
    public Guid DeletedBy { get; set; }

    public bool IsDeleted => DeletedAt != DateTime.MinValue;
}
