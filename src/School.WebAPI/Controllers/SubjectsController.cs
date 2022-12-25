using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using School.Application.CQRS.KnowledgeAreas;
using School.Application.CQRS.Subjects;
using School.Application.DTO;
using School.Application.Results;
using School.WebAPI.Helpers;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public SubjectsController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQueryPaginatedResult]
        public async Task<IQueryable<SubjectDto>> GetAllAsync(ODataQueryOptions options, CancellationToken cancellationToken)
        {
            var subjects = await _mediator.Send(new GetAllSubjectsRequest(), cancellationToken);

            var expand = Expand.GetMembersToExpandNames(options);

            var subjectsDto = subjects.ProjectTo<SubjectDto>(_mapper.ConfigurationProvider, null, expand);

            return subjectsDto;
        }

        [HttpGet("{id}")]
        [EnableQueryResult]
        public async Task<IQueryable<SubjectDto>> GetByIdAsync(ODataQueryOptions options, int id, CancellationToken cancellationToken)
        {
            var subjects = await _mediator.Send(new GetSubjectByIdRequest { Id = id }, cancellationToken);

            var expand = Expand.GetMembersToExpandNames(options);

            var subjectsDto = subjects.ProjectTo<SubjectDto>(_mapper.ConfigurationProvider, null, expand);

            return subjectsDto;

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostSubjectRequest request, CancellationToken cancellationToken)
        {
            var subject = await _mediator.Send(request, cancellationToken);

            var subjectDto = _mapper.Map<SubjectDto>(subject);

            var result = Result<SubjectDto>.Success(subjectDto);

            return CreatedAtAction("GetById", "Subjects", new { id = subject.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(PutSubjectRequest request, int id, CancellationToken cancellationToken)
        {
            request.Id = id;

            var subject = await _mediator.Send(request, cancellationToken);

            var subjectDto = _mapper.Map<SubjectDto>(subject);

            var result = Result<SubjectDto>.Success(subjectDto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteSubjectRequest { Id = id }, cancellationToken);

            var result = Result<SubjectDto>.Success();

            return NoContent();
        }
    }
}
