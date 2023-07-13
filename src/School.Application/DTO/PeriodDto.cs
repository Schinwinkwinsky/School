using School.Domain.Entities;

namespace School.Application.DTO;

public class PeriodDto : IDto<Period>
{
    public Guid Id { get; set; }

    public string Code { get; set; } = default!;

    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    // Navigation properties.
    public Guid CourseId { get; set; }
    public Course? Course { get; set; }

    public ICollection<SchoolClassDto>? SchoolClasses { get; set; }

    public void CopyToEntity(Period period)
    {
        period.Id = Id;
        period.Code = Code;
        period.StartDate = StartDate;
        period.EndDate = EndDate;
        period.CourseId = CourseId;
    }
}
