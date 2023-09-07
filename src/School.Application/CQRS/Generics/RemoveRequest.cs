using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Generics;

public class RemoveRequest<T> : IRequest
    where T : EntityBase
{
    public Guid Id { get; set; }

    public RemoveRequest(Guid id)
        => Id = id;
}

public class RemoveRequestHandler<T> : IRequestHandler<RemoveRequest<T>>
    where T : EntityBase
{
    private readonly IUnitOfWork _unitOfWork;

    public RemoveRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task Handle(RemoveRequest<T> request, CancellationToken cancellationToken)
    {
        var item = await _unitOfWork.Repository<T>().GetAsync(request.Id, cancellationToken);

        if (item is null || item.IsDeleted)
            throw new HttpRequestException($"{ typeof(T).Name } with id = { request.Id } was not found.", null, HttpStatusCode.NotFound);

        item.DeletedAt = DateTime.Now;

        await _unitOfWork.SaveChangesAsync(cancellationToken);            
    }
}
