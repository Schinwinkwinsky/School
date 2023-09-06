using MediatR;
using School.Application.DTO;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Generics;

public class UpdateRequest<T, TDto> : IRequest<T>
    where T : EntityBase
    where TDto : IDto<T>
{
    public TDto Dto { get; set; } = default!;

    public UpdateRequest(TDto dto)
        => Dto = dto;
}

public class PutRequestHandler<T, TDto> : IRequestHandler<UpdateRequest<T, TDto>, T>
    where T : EntityBase
    where TDto : IDto<T>
{
    private readonly IUnitOfWork _unitOfWork;

    public PutRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<T> Handle(UpdateRequest<T, TDto> request, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.Repository<T>()
            .GetAsync(request.Dto.Id, cancellationToken);

        if (item is null || item.IsDeleted)
            throw new HttpRequestException($"{ typeof(T).Name } with id = { request.Dto.Id } was not found.", null, HttpStatusCode.NotFound);

        request.Dto.CopyToEntity(item);

        item.UpdatedAt = DateTime.Now;

        await _unitOfWork.SaveChangesAsync();

        return item;
    }
}
