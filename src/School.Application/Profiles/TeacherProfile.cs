using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<Teacher, TeacherDto>()
            .ForMember(t => t.Person, opt => opt.ExplicitExpansion())
            .ForMember(t => t.KnowledgeAreas, opt => opt.ExplicitExpansion())
            .ForMember(t => t.SchoolClasses, opt => opt.ExplicitExpansion());
    }
}
