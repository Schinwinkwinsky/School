using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class SubjectProfile : Profile
{
    public SubjectProfile()
    {
        CreateMap<Subject, SubjectDto>()
            .ForMember(s => s.KnowledgeAreas, opt => opt.ExplicitExpansion());
    }
}
