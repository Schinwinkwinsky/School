using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.KnowledgeAreas;
using School.Application.CQRS.Subjects;
using School.Domain.Entities;
using School.WebAPI.Helpers;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubjectsController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [EnableQueryPaginatedResult]
        public async Task<IEnumerable<Subject>> GetAllAsync(bool includeDeleted, CancellationToken cancellationToken)
            => await _mediator.Send(new GetAllSubjectsRequest { IncludeDeleted = includeDeleted }, cancellationToken);

        [HttpGet("id")]
        [EnableQueryResult]
        public async Task<IEnumerable<Subject>> GetByIdAsync(int id, bool includeDeleted, CancellationToken cancellationToken)
            => await _mediator.Send(new GetSubjectByIdRequest { Id = id, IncludeDeleted = includeDeleted }, cancellationToken);

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostSubjectRequest request, CancellationToken cancellationToken)
        {
            var subject = await _mediator.Send(request, cancellationToken);

            return CreatedAtAction("GetById", "Subjects", new { id = subject.Id }, subject);
        }
    }
}
