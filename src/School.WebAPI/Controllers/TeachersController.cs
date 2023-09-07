using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.CQRS.Relations.Teachers;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class TeachersController : ApiBaseController<
    Teacher,
    TeacherModel,
    TeacherDto,
    GetAllRequest<Teacher>,
    GetByIdRequest<Teacher>,
    InsertRequest<Teacher, TeacherModel>,
    UpdateRequest<Teacher, TeacherDto>,
    RemoveRequest<Teacher>>
{
    public TeachersController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }

    [HttpDelete("{id}")]
    public override async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new TeacherRemoveRelationsRequest(id);

        await _mediator.Send(request, cancellationToken);

        return await base.RemoveAsync(id, cancellationToken);
    }

    [HttpPost("{id}/knowledgeAreas/add")]
    public async Task<IActionResult> AddKnowledgeAreas(Guid id, Guid[] knowledgeAreaIds, CancellationToken cancellationToken)
    {
        var request = new TeacherAddKnowledgeAreasRequest(id, knowledgeAreaIds);

        var teacher = await _mediator.Send(request, cancellationToken);

        var teacherDto = _mapper.Map<Teacher, TeacherDto>(teacher);

        var result = Result<TeacherDto>.Success(teacherDto);

        return Ok(result);
    }

    [HttpPost("{id}/knowledgeAreas/remove")]
    public async Task<IActionResult> RemoveKnowledgeAreas(Guid id, Guid[] knowledgeAreaIds, CancellationToken cancellationToken)
    {
        var request = new TeacherRemoveKnowledgeAreasRequest(id, knowledgeAreaIds);

        var teacher = await _mediator.Send(request, cancellationToken);

        var teacherDto = _mapper.Map<Teacher, TeacherDto>(teacher);

        var result = Result<TeacherDto>.Success(teacherDto);

        return Ok(result);
    }
}
