using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.CQRS.Relations.KnowledgeAreas;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class KnowledgeAreasController : ApiBaseController<
    KnowledgeArea,
    KnowledgeAreaModel,
    KnowledgeAreaDto,
    GetAllRequest<KnowledgeArea>,
    GetByIdRequest<KnowledgeArea>,
    InsertRequest<KnowledgeArea, KnowledgeAreaModel>,
    UpdateRequest<KnowledgeArea, KnowledgeAreaDto>,
    RemoveRequest<KnowledgeArea>>
{
    public KnowledgeAreasController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }

    [HttpDelete("{id}")]
    public async override Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new KnowledgeAreaRemoveRelationsRequest(id);

        await _mediator.Send(request, cancellationToken);

        return await base.RemoveAsync(id, cancellationToken);
    }

    [HttpPost("{id}/subjects/add")]
    public async Task<IActionResult> AddSubjects(Guid id, Guid[] subjectIds, CancellationToken cancellationToken)
    {
        var request = new KnowledgeAreaAddSubjectsRequest(id, subjectIds);

        var knowledgeArea = await _mediator.Send(request, cancellationToken);

        var knowledgeAreaDto = _mapper.Map<KnowledgeArea, KnowledgeAreaDto>(knowledgeArea);

        var result = Result<KnowledgeAreaDto>.Success(knowledgeAreaDto);

        return Ok(result);
    }

    [HttpPost("{id}/teachers/add")]
    public async Task<IActionResult> AddTeachers(Guid id, Guid[] teacherIds, CancellationToken cancellationToken)
    {
        var request = new KnowledgeAreaAddTeachersRequest(id, teacherIds);

        var knowledgeArea = await _mediator.Send(request, cancellationToken);

        var knowledgeAreaDto = _mapper.Map<KnowledgeArea, KnowledgeAreaDto>(knowledgeArea);

        var result = Result<KnowledgeAreaDto>.Success(knowledgeAreaDto);

        return Ok(result);
    }

    [HttpPost("{id}/subjects/remove")]
    public async Task<IActionResult> RemoveSubjects(Guid id, Guid[] subjectIds, CancellationToken cancellationToken)
    {
        var request = new KnowledgeAreaRemoveSubjectsRequest(id, subjectIds);

        var knowledgeArea = await _mediator.Send(request, cancellationToken);

        var knowledgeAreaDto = _mapper.Map<KnowledgeArea, KnowledgeAreaDto>(knowledgeArea);

        var result = Result<KnowledgeAreaDto>.Success(knowledgeAreaDto);

        return Ok(result);
    }

    [HttpPost("{id}/teachers/remove")]
    public async Task<IActionResult> RemoveTeachers(Guid id, Guid[] teacherIds, CancellationToken cancellationToken)
    {
        var request = new KnowledgeAreaRemoveTeachersRequest(id, teacherIds);

        var knowledgeArea = await _mediator.Send(request, cancellationToken);

        var knowledgeAreaDto = _mapper.Map<KnowledgeArea, KnowledgeAreaDto>(knowledgeArea);

        var result = Result<KnowledgeAreaDto>.Success(knowledgeAreaDto);

        return Ok(result);
    }
}
