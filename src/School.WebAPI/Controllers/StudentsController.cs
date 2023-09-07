using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.CQRS.Relations.Students;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class StudentsController : ApiBaseController<
    Student,
    StudentModel,
    StudentDto,
    GetAllRequest<Student>,
    GetByIdRequest<Student>,
    InsertRequest<Student, StudentModel>,
    UpdateRequest<Student, StudentDto>,
    RemoveRequest<Student>>
{
    public StudentsController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }

    [HttpDelete("{id}")]
    public override async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new StudentRemoveRelationsRequest(id);

        await _mediator.Send(request, cancellationToken);

        return await base.RemoveAsync(id, cancellationToken);
    }

    [HttpPost("{id}/schoolClasses/add")]
    public async Task<IActionResult> AddSchoolClasses(Guid id, Guid[] schoolClassIds, CancellationToken cancellationToken)
    {
        var request = new StudentAddSchoolClassesRequest(id, schoolClassIds);

        var student = await _mediator.Send(request, cancellationToken);

        var studentDto = _mapper.Map<Student, StudentDto>(student);

        var result = Result<StudentDto>.Success(studentDto);

        return Ok(result);
    }

    [HttpPost("{id}/schoolClasses/remove")]
    public async Task<IActionResult> RemoveSchoolClasses(Guid id, Guid[] schoolClassIds, CancellationToken cancellationToken)
    {
        var request = new StudentRemoveSchoolClassesRequest(id, schoolClassIds);

        var student = await _mediator.Send(request, cancellationToken);

        var studentDto = _mapper.Map<Student, StudentDto>(student);

        var result = Result<StudentDto>.Success(studentDto);

        return Ok(result);
    }
}
