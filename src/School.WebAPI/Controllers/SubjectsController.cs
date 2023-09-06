using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.CQRS.Relations.Subjects;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class SubjectsController : ApiControllerBase<
    Subject,
    SubjectModel,
    SubjectDto,
    GetAllRequest<Subject>,
    GetByIdRequest<Subject>,
    InsertRequest<Subject, SubjectModel>,
    UpdateRequest<Subject, SubjectDto>,
    RemoveRequest<Subject>>
{
    public SubjectsController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }

    [HttpDelete("{id}")]
    public override async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = new SubjectRemoveRelationsRequest(id);

        await _mediator.Send(request, cancellationToken);

        return await base.RemoveAsync(id, cancellationToken);
    }

    [HttpPost("{id}/courses/add")]
    public async Task<IActionResult> AddCourses(Guid id, Guid[] courseIds, CancellationToken cancellationToken)
    {
        var request = new SubjectAddCoursesRequest(id, courseIds);

        var subject = await _mediator.Send(request, cancellationToken);

        var subjectDto = _mapper.Map<Subject, SubjectDto>(subject);

        var result = Result<SubjectDto>.Success(subjectDto);

        return Ok(result);
    }

    [HttpPost("{id}/knowledgeAreas/add")]
    public async Task<IActionResult> AddKnowledgeAreas(Guid id, Guid[] knowledgeAreaIds, CancellationToken cancellationToken)
    {
        var request = new SubjectAddKnowledgeAreasRequest(id, knowledgeAreaIds);

        var subject = await _mediator.Send(request, cancellationToken);

        var subjectDto = _mapper.Map<Subject, SubjectDto>(subject);

        var result = Result<SubjectDto>.Success(subjectDto);

        return Ok(result);
    }

    [HttpPost("{id}/courses/remove")]
    public async Task<IActionResult> RemoveCourses(Guid id, Guid[] courseIds, CancellationToken cancellationToken)
    {
        var request = new SubjectRemoveCoursesRequest(id, courseIds);

        var subject = await _mediator.Send(request, cancellationToken);

        var subjectDto = _mapper.Map<Subject, SubjectDto>(subject);

        var result = Result<SubjectDto>.Success(subjectDto);

        return Ok(result);
    }

    [HttpPost("{id}/knowledgeAreas/remove")]
    public async Task<IActionResult> RemoveKnowledgeAreas(Guid id, Guid[] knowledgeAreaIds, CancellationToken cancellationToken)
    {
        var request = new SubjectRemoveKnowledgeAreasRequest(id, knowledgeAreaIds);

        var subject = await _mediator.Send(request, cancellationToken);

        var subjectDto = _mapper.Map<Subject, SubjectDto>(subject);

        var result = Result<SubjectDto>.Success(subjectDto);

        return Ok(result);
    }
}
