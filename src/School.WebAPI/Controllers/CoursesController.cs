using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.CQRS.Relations.Courses;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class CoursesController : ApiBaseController<
    Course,
    CourseModel,
    CourseDto,
    GetAllRequest<Course>,
    GetByIdRequest<Course>,
    InsertRequest<Course, CourseModel>,
    UpdateRequest<Course, CourseDto>,
    RemoveRequest<Course>>
{
    public CoursesController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }

    [HttpDelete("{id}")]
    public async override Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new CourseRemoveRelationsRequest(id);

        await _mediator.Send(request, cancellationToken);

        return await base.RemoveAsync(id, cancellationToken);
    }

    [HttpPost("{id}/subjects/add")]
    public async Task<IActionResult> AddSubjectsAsync(Guid id, Guid[] subjectIds, CancellationToken cancellationToken)
    {
        var request = new CourseAddSubjectsRequest(id, subjectIds);

        var course = await _mediator.Send(request, cancellationToken);

        var courseDto = _mapper.Map<Course, CourseDto>(course);

        var result = Result<CourseDto>.Success(courseDto);

        return Ok(result);
    }

    [HttpPost("{id}/subjects/remove")]
    public async Task<IActionResult> RemoveSubjectsAsync(Guid id, Guid[] subjectIds, CancellationToken cancellationToken)
    {
        var request = new CourseRemoveSubjectsRequest(id, subjectIds);

        var course = await _mediator.Send(request, cancellationToken);

        var courseDto = _mapper.Map<Course, CourseDto>(course);

        var result = Result<CourseDto>.Success(courseDto);

        return Ok(result);
    }
}
