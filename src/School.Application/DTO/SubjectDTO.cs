﻿using School.Domain.Entities;

namespace School.Application.DTO;

public class SubjectDto : IDto<Subject>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;

    // Navigation properties.
    public ICollection<CourseDto>? Courses { get; set; }
    public ICollection<KnowledgeAreaDto>? KnowledgeAreas { get; set; }
    public ICollection<SchoolClassDto>? SchoolClasses { get; set; }

    public void CopyToEntity(Subject item)
    {
        item.Id = Id;
        item.Name = Name;
    }
}
