using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ApiControllerBase<
        Course,
        CourseModel,
        CourseDto,
        GetAllRequest<Course>,
        GetByIdRequest<Course>,
        PostRequest<Course, CourseModel>,
        PutRequest<Course, CourseDto>,
        DeleteRequest<Course>>
    {
        public CoursesController(IMapper mapper, IMediator mediator)
            : base(mapper, mediator) { }
    }
}
