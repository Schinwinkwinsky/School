using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Teachers;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ApiControllerBase<
        Teacher,
        TeacherDto,
        GetAllTeachersRequest,
        GetTeacherByIdRequest,
        PostTeacherRequest,
        PutTeacherRequest,
        DeleteTeacherRequest>
    {
        public TeachersController(IMapper mapper, IMediator mediator)
            : base(mapper, mediator) { }
    }
}
