using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.CQRS.Subjects;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ApiControllerBase<
        Subject,
        SubjectModel,
        SubjectDto,
        GetAllRequest<Subject>,
        GetByIdRequest<Subject>,
        PostRequest<Subject, SubjectModel>,
        PutRequest<Subject, SubjectDto>,
        DeleteRequest<Subject>>
    {
        public SubjectsController(IMapper mapper, IMediator mediator)
            : base(mapper, mediator) { }

        [HttpPost("{id}/knowledgeAreas/add")]
        public async Task<IActionResult> AddKnowledgeAreasAsync(int id, AddSubjectKnowledgeAreasRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var subject = await _mediator.Send(request, cancellationToken);

            var subjectDto = _mapper.Map<SubjectDto>(subject);

            var result = Result<SubjectDto>.Success(subjectDto);

            return Ok(result);
        }

        [HttpPost("{id}/knowledgeAreas/remove")]
        public async Task<IActionResult> RemoveKnowledgeAreasAsync(int id, RemoveSubjectKnowledgeAreasRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var subject = await _mediator.Send(request, cancellationToken);

            var subjectDto = _mapper.Map<SubjectDto>(subject);

            var result = Result<SubjectDto>.Success(subjectDto);

            return Ok(result);
        }
    }
}
