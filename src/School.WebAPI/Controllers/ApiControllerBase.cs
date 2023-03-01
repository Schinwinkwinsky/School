using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;
using School.WebAPI.Attributes;
using School.WebAPI.Helpers;

namespace School.WebAPI.Controllers
{
    [ApiController]
    public class ApiControllerBase<
        T,
        TModel,
        TDto,
        TGetAllRequest,
        TGetByIdRequest,
        TPostRequest,
        TPutRequest,
        TDeleteRequest> : ControllerBase 
        where T : EntityBase
        where TModel : IModel<T>
        where TDto : IDto<T>
        where TGetAllRequest : IRequest<IQueryable<T>>
        where TGetByIdRequest : IRequest<IQueryable<T>>
        where TPostRequest : IRequest<T>
        where TPutRequest : IRequest<T>
        where TDeleteRequest : IRequest
    {
        protected readonly IMapper _mapper;
        protected readonly IMediator _mediator;

        public ApiControllerBase(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQueryPaginatedResult]
        public async Task<IQueryable<TDto>> GetAllAsync(ODataQueryOptions options, CancellationToken cancellationToken)
        {
            var handler = Activator.CreateInstance<TGetAllRequest>();

            var items = await _mediator.Send(handler!, cancellationToken) as IQueryable<T>;

            var expand = Expand.GetMembersToExpandNames(options);

            var itemsDto = items!.ProjectTo<TDto>(_mapper.ConfigurationProvider, null, expand);

            return itemsDto;
        }

        [HttpGet("{id}")]
        [EnableQueryResult]
        public async Task<IQueryable<TDto>> GetByIdAsync(ODataQueryOptions options, int id, bool includeDeleted, CancellationToken cancellationToken)
        {
            var handler = Activator.CreateInstance(typeof(TGetByIdRequest), id);

            var items = await _mediator.Send(handler!, cancellationToken) as IQueryable<T>;

            var expand = Expand.GetMembersToExpandNames(options);

            var itemsDto = items.ProjectTo<TDto>(_mapper.ConfigurationProvider, null, expand);

            return itemsDto;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(TModel model, CancellationToken cancellationToken)
        {
            var handler = Activator.CreateInstance(typeof(TPostRequest), model);

            var item = await _mediator.Send(handler!, cancellationToken) as T;

            var itemDto = _mapper.Map<TDto>(item);

            var result = Result<TDto>.Success(itemDto);

            return CreatedAtAction("GetById", new { id = item!.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(TDto dto, int id, CancellationToken cancellationToken)
        {
            dto.Id = id;

            var handler = Activator.CreateInstance(typeof(TPutRequest), dto);

            var item = await _mediator.Send(handler!, cancellationToken) as T;

            var itemDto = _mapper.Map<TDto>(item);

            var result = Result<TDto>.Success(itemDto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var handler = Activator.CreateInstance(typeof(TDeleteRequest), id);

            await _mediator.Send(handler!, cancellationToken);

            return NoContent();
        }
    }
}
