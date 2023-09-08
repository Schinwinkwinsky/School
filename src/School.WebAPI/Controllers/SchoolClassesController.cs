using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.CQRS.Relations.SchoolClasses;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class SchoolClassesController : ApiBaseController<
SchoolClass,
SchoolClassModel,
SchoolClassDto,
GetAllRequest<SchoolClass>,
GetByIdRequest<SchoolClass>,
InsertRequest<SchoolClass, SchoolClassModel>,
UpdateRequest<SchoolClass, SchoolClassDto>,
RemoveRequest<SchoolClass>>
{
    public SchoolClassesController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }

    [HttpDelete("{id}")]
    public override async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new SchoolClassRemoveRelationsRequest(id);

        await _mediator.Send(request, cancellationToken);

        return await base.RemoveAsync(id, cancellationToken);
    }

    [HttpPost("{id}/students/add")]
    public async Task<IActionResult> AddStudentsAsync(Guid id, Guid[] studentIds, CancellationToken cancellationToken)
    {
        var request = new SchoolClassAddStudentsRequest(id, studentIds);

        var schoolClass = await _mediator.Send(request, cancellationToken);

        var schoolClassDto = _mapper.Map<SchoolClass, SchoolClassDto>(schoolClass);

        var result = Result<SchoolClassDto>.Success(schoolClassDto);

        return Ok(result);
    }

    [HttpPost("{id}/students/remove")]
    public async Task<IActionResult> RemoveStudentsAsync(Guid id, Guid[] studentIds, CancellationToken cancellationToken)
    {
        var request = new SchoolClassRemoveStudentsRequest(id, studentIds);

        var schoolClass = await _mediator.Send(request, cancellationToken);

        var schoolClassDto = _mapper.Map<SchoolClass, SchoolClassDto>(schoolClass);

        var result = Result<SchoolClassDto>.Success(schoolClassDto);

        return Ok(result);
    }
}
