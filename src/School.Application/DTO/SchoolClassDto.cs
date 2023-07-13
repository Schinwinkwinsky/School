using School.Domain.Entities;

namespace School.Application.DTO;

public class SchoolClassDto : IDto<SchoolClass>
{
    public Guid Id { get; set; }

    public string Code { get; set; } = string.Empty;

    // Navigation properties.
    public Guid PeriodId { get; set; }
    public PeriodDto? Period { get; set; }

    public Guid SubjectId { get; set; }
    public SubjectDto? Subject { get; set; }

    public Guid TeacherId { get; set; }
    public TeacherDto? Teacher { get; set; }

    public ICollection<StudentDto>? Students { get; set; }

    public void CopyToEntity(SchoolClass schoolClass)
    {
        schoolClass.Id = Id;
        schoolClass.Code = Code;
        schoolClass.PeriodId = PeriodId;
        schoolClass.SubjectId = SubjectId;
        schoolClass.TeacherId = TeacherId;
    }
}
