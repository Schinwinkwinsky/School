using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class SubjectProfile : Profile
{
    public SubjectProfile()
    {
        CreateMap<Subject, SubjectDto>()
            .ForMember(s => s.Courses, opt =>
            {
                opt.ExplicitExpansion();
                opt.MapFrom(s => s.Courses.Where(c => c.DeletedAt == default));
            })
            .ForMember(s => s.KnowledgeAreas, opt =>
            {
                opt.ExplicitExpansion();
                opt.MapFrom(s => s.KnowledgeAreas.Where(ka => ka.DeletedAt == default));
            })
            .ForMember(s => s.SchoolClasses, opt => 
            { 
                opt.ExplicitExpansion(); 
                opt.MapFrom(s => s.SchoolClasses.Where(sc => sc.DeletedAt == default)); 
            });
    }
}
