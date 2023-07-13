using AutoMapper;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Profiles;

public class KnowledgeAreaProfile : Profile
{
    public KnowledgeAreaProfile()
    {
        CreateMap<KnowledgeArea, KnowledgeAreaDto>()
            .ForMember(ka => ka.Subjects, opt => opt.ExplicitExpansion())
            .ForMember(ka => ka.Teachers, opt => opt.ExplicitExpansion());
    }
}
