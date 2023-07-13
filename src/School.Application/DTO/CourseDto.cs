﻿using School.Domain.Entities;

namespace School.Application.DTO;

public class CourseDto : IDto<Course>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<SubjectDto>? Subjects { get; set; }

    public void CopyToEntity(Course item)
    {
        item.Id = Id;
        item.Name = Name;
    }
}
