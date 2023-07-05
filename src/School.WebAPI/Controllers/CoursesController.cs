using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Courses;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
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

        [HttpPost("{id}/subjects/add")]
        public async Task<IActionResult> AddSubjectsAsync(Guid id, AddCourseSubjectsRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var course = await _mediator.Send(request, cancellationToken);

            var courseDto = _mapper.Map<CourseDto>(course);

            var result = Result<CourseDto>.Success(courseDto);

            return Ok(result);
        }
    }
}
