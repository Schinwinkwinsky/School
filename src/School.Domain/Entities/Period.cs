namespace School.Domain.Entities;

public class Period : EntityBase
{
    public string Code { get; set; } = default!;

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Navigation properties.
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = default!;

    public virtual ICollection<SchoolClass> SchoolClasses { get; set; } = default!;
}
