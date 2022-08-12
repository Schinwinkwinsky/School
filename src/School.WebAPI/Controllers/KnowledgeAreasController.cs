using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.KnowledgeAreas;
using School.Domain.Entities;
using School.WebAPI.Other;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeAreasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KnowledgeAreasController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet]
        [EnableQueryPaginatedResult]
        public async Task<IEnumerable<KnowledgeArea>> GetAllAsync(bool includeDeleted, CancellationToken cancellationToken)
            => await _mediator.Send(new GetAllKnowledgeAreasRequest { IncludeDeleted = includeDeleted }, cancellationToken);

        [HttpGet("id")]
        public async Task<IEnumerable<KnowledgeArea>> GetByIdAsync(int id, bool includeDeleted, CancellationToken cancellationToken)
            => await _mediator.Send(new GetKnowledgeAreaByIdRequest { Id = id, IncludeDeleted = includeDeleted }, cancellationToken);

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostKnowledgeAreaRequest request, CancellationToken cancellationToken)
        {
            var knowledgeArea = await _mediator.Send(request, cancellationToken);

            return CreatedAtAction("GetById", "KnowledgeAreas", new { id = knowledgeArea.Id }, knowledgeArea);
        }
    }
}
