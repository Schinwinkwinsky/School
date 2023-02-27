using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.KnowledgeAreas;
using School.Application.CQRS.Subjects;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ApiControllerBase<
        Subject,
        SubjectDto,
        GetAllSubjectsRequest,
        GetSubjectByIdRequest,
        PostSubjectRequest,
        PutSubjectRequest,
        DeleteSubjectRequest>
    {
        public SubjectsController(IMapper mapper, IMediator mediator)
            : base(mapper, mediator) { }
    }
}
