namespace School.Domain.Entities;

public class Period : EntityBase
{
    public string Code { get; set; } = string.Empty;

    public DateTime Start { get; set; }
    public DateTime End { get; set; }

    // Navigation properties.
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; } = new();

    public virtual ICollection<SchoolClass> SchoolClasses { get; set; } = new List<SchoolClass>();
}
