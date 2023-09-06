using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDto>()
            .ForMember(s => s.Person, opt => opt.ExplicitExpansion())
            .ForMember(s => s.SchoolClasses, opt =>
            {
                opt.ExplicitExpansion();
                opt.MapFrom(s => s.SchoolClasses.Where(sc => sc.DeletedAt == default));
            });
    }
}
