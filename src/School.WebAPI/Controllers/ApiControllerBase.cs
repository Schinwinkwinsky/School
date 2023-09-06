using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;
using School.WebAPI.Attributes;
using School.WebAPI.Helpers;

namespace School.WebAPI.Controllers;

[ApiController]
public class ApiControllerBase<
    T,
    TModel,
    TDto,
    TGetAllRequest,
    TGetByIdRequest,
    TInsertRequest,
    TUpdateRequest,
    TRemoveRequest> : ControllerBase 
    where T : EntityBase
    where TModel : IModel<T>
    where TDto : IDto<T>
    where TGetAllRequest : IRequest<IQueryable<T>>
    where TGetByIdRequest : IRequest<IQueryable<T>>
    where TInsertRequest : IRequest<T>
    where TUpdateRequest : IRequest<T>
    where TRemoveRequest : IRequest
{
    protected readonly IMapper _mapper;
    protected readonly IMediator _mediator;

    public ApiControllerBase(IMapper mapper, IMediator mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpGet]
    [EnableQueryPaginatedResult(MaxExpansionDepth = 3, MaxAnyAllExpressionDepth = 2)]
    public async Task<IQueryable<TDto>> GetAllAsync([FromServices] ODataQueryOptions options, CancellationToken cancellationToken)
    {
        var request = Activator.CreateInstance<TGetAllRequest>() as GetAllRequest<T>;

        var items = await _mediator.Send(request!, cancellationToken) as IQueryable<T>;

        var expand = ODataExpandHelper.GetMembersToExpandNames(options);

        var itemsDto = items!.ProjectTo<TDto>(_mapper.ConfigurationProvider, null, expand);

        return itemsDto;
    }

    [HttpGet("{id}")]
    [EnableQueryResult]
    public async Task<IQueryable<TDto>> GetByIdAsync([FromServices] ODataQueryOptions options, Guid id, bool includeDeleted, CancellationToken cancellationToken)
    {
        var request = Activator.CreateInstance(typeof(TGetByIdRequest), id) as GetByIdRequest<T>;

        var items = await _mediator.Send(request!, cancellationToken) as IQueryable<T>;

        var expand = ODataExpandHelper.GetMembersToExpandNames(options);

        var itemsDto = items.ProjectTo<TDto>(_mapper.ConfigurationProvider, null, expand);

        return itemsDto;
    }

    [HttpPost]
    public async Task<IActionResult> InsertAsync(TModel model, CancellationToken cancellationToken)
    {
        var request = Activator.CreateInstance(typeof(TInsertRequest), model) as InsertRequest<T, TModel>;

        var item = await _mediator.Send(request!, cancellationToken) as T;

        var itemDto = _mapper.Map<TDto>(item);

        var result = Result<TDto>.Success(itemDto);

        return CreatedAtAction("GetById", new { id = item!.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(TDto dto, Guid id, CancellationToken cancellationToken)
    {
        dto.Id = id;

        var request = Activator.CreateInstance(typeof(TUpdateRequest), dto) as UpdateRequest<T, TDto>;

        var item = await _mediator.Send(request!, cancellationToken) as T;

        var itemDto = _mapper.Map<TDto>(item);

        var result = Result<TDto>.Success(itemDto);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var request = Activator.CreateInstance(typeof(TRemoveRequest), id) as RemoveRequest<T>;

        await _mediator.Send(request!, cancellationToken);

        return NoContent();
    }
}
