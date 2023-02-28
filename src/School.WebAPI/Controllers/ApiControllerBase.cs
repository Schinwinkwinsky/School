using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using School.Application.Interfaces;
using School.Application.Results;
using School.Domain.Entities;
using School.WebAPI.Attributes;
using School.WebAPI.Helpers;

namespace School.WebAPI.Controllers
{
    [ApiController]
    public class ApiControllerBase<T,TDto,U,V,W,X,Y> : ControllerBase 
        where T : EntityBase 
        where X : IIdentifiable
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ApiControllerBase(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQueryPaginatedResult]
        public async Task<IQueryable<TDto>> GetAllAsync(ODataQueryOptions options, CancellationToken cancellationToken)
        {
            var handle = Activator.CreateInstance<U>();

            var items = await _mediator.Send(handle!, cancellationToken) as IQueryable<T>;

            var expand = Expand.GetMembersToExpandNames(options);

            var itemsDto = items!.ProjectTo<TDto>(_mapper.ConfigurationProvider, null, expand);

            return itemsDto;
        }

        [HttpGet("{id}")]
        [EnableQueryResult]
        public async Task<IQueryable<TDto>> GetByIdAsync(ODataQueryOptions options, int id, bool includeDeleted, CancellationToken cancellationToken)
        {
            var handle = Activator.CreateInstance(typeof(V), id);

            var items = await _mediator.Send(handle!, cancellationToken) as IQueryable<T>;

            var expand = Expand.GetMembersToExpandNames(options);

            var itemsDto = items.ProjectTo<TDto>(_mapper.ConfigurationProvider, null, expand);

            return itemsDto;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(W request, CancellationToken cancellationToken)
        {
            var item = await _mediator.Send(request!, cancellationToken) as T;

            var itemDto = _mapper.Map<TDto>(item);

            var result = Result<TDto>.Success(itemDto);

            return CreatedAtAction("GetById", new { id = item!.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(X request, int id, CancellationToken cancellationToken)
        {
            request.Id = id;

            var item = await _mediator.Send(request, cancellationToken) as T;

            var itemDto = _mapper.Map<TDto>(item);

            var result = Result<TDto>.Success(itemDto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var handle = Activator.CreateInstance(typeof(Y), id);

            await _mediator.Send(handle!, cancellationToken);

            return NoContent();
        }
    }
}
