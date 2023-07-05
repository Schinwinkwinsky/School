using AutoMapper;
using School.Application.DTO;
using School.Domain.ValueObjects;

namespace School.Application.Profiles
{
    public class EmailProfile : Profile
    {
        public EmailProfile()
        {
            CreateMap<Email, EmailDto>();
        }
    }
}
