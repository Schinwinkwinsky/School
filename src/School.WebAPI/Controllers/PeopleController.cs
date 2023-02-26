using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using School.Application.CQRS.People;
using School.Application.DTO;
using School.Application.Results;
using School.WebAPI.Attributes;
using School.WebAPI.Helpers;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PeopleController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQueryPaginatedResult]
        public async Task<IQueryable<PersonDto>> GetAllAsync(ODataQueryOptions options, CancellationToken cancellationToken)
        {
            var people = await _mediator.Send(new GetAllPeopleRequest(), cancellationToken);

            var expand = Expand.GetMembersToExpandNames(options);

            var peopleDto = people.ProjectTo<PersonDto>(_mapper.ConfigurationProvider, null, expand);

            return peopleDto;
        }

        [HttpGet("{id}")]
        [EnableQueryResult]
        public async Task<IQueryable<PersonDto>> GetByIdAsync(ODataQueryOptions options, int id, CancellationToken cancellationToken)
        {
            var people = await _mediator.Send(new GetPersonByIdRequest { Id = id }, cancellationToken);

            var expand = Expand.GetMembersToExpandNames(options);

            var peopleDto = people.ProjectTo<PersonDto>(_mapper.ConfigurationProvider, null, expand);

            return peopleDto;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostPersonRequest request, CancellationToken cancellationToken)
        {
            var person = await _mediator.Send(request, cancellationToken);

            var personDto = _mapper.Map<PersonDto>(person);

            var result = Result<PersonDto>.Success(personDto);

            return CreatedAtAction("GetById", "People", new { id = person.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(PutPersonRequest request, int id, CancellationToken cancellationToken)
        {
            request.Id = id;

            var person = await _mediator.Send(request, cancellationToken);

            var personDto = _mapper.Map<PersonDto>(person);

            var result = Result<PersonDto>.Success(personDto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeletePersonRequest { Id = id }, cancellationToken);

            return NoContent();
        }
    }
}
