using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using School.Application.CQRS.KnowledgeAreas;
using School.Application.DTO;
using School.Application.Results;
using School.WebAPI.Helpers;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeAreasController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public KnowledgeAreasController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQueryPaginatedResult]
        public async Task<IQueryable<KnowledgeAreaDTO>> GetAllAsync(ODataQueryOptions options, CancellationToken cancellationToken)
        {
            var areas = await _mediator.Send(new GetAllKnowledgeAreasRequest(), cancellationToken);

            var expand = Expand.GetMembersToExpandNames(options);

            var areasDto = areas.ProjectTo<KnowledgeAreaDTO>(_mapper.ConfigurationProvider, null, expand);

            return areasDto;
        }

        [HttpGet("{id}")]
        [EnableQueryResult]
        public async Task<IQueryable<KnowledgeAreaDTO>> GetByIdAsync(ODataQueryOptions options, int id, bool includeDeleted, CancellationToken cancellationToken)
        {
            var area = await _mediator.Send(new GetKnowledgeAreaByIdRequest { Id = id }, cancellationToken);

            var expand = Expand.GetMembersToExpandNames(options);

            var areaDto = area.ProjectTo<KnowledgeAreaDTO>(_mapper.ConfigurationProvider, null, expand);

            return areaDto;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostKnowledgeAreaRequest request, CancellationToken cancellationToken)
        {
            var area = await _mediator.Send(request, cancellationToken);

            var areaDto = _mapper.Map<KnowledgeAreaDTO>(area);

            var result = Result<KnowledgeAreaDTO>.Success(areaDto);

            return CreatedAtAction("GetById", "KnowledgeAreas", new { id = area.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(PutKnowledgeAreaRequest request, int id, CancellationToken cancellationToken)
        {
            request.Id = id;

            var area = await _mediator.Send(request, cancellationToken);

            var areaDto = _mapper.Map<KnowledgeAreaDTO>(area);

            var result = Result<KnowledgeAreaDTO>.Success(areaDto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteKnowledgeAreaRequest { Id = id }, cancellationToken);

            var result = Result<KnowledgeAreaDTO>.Success();

            return NoContent();
        }
    }
}
