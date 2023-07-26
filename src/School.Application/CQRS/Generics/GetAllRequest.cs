using MediatR;
using School.Domain.Entities;
using School.Domain;

namespace School.Application.CQRS.Generics;

public class GetAllRequest<T> : IRequest<IQueryable<T>> 
    where T : EntityBase { }

public class GetAllRequestHandler<T> : IRequestHandler<GetAllRequest<T>, IQueryable<T>> 
    where T : EntityBase
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<IQueryable<T>> Handle(GetAllRequest<T> request, CancellationToken cancellationToken)
    {
        var items = _unitOfWork.Repository<T>().GetAll()
            .Where(i => i.DeletedAt == DateTime.MinValue
                && i.DeletedBy == Guid.Empty);

        return await Task.FromResult(items);
    }
}
