using MediatR;
using School.Application.Models;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.Generics;

public class InsertRequest<T, TModel> : IRequest<T> 
    where T : EntityBase
    where TModel : IModel<T>
{
    public TModel Model { get; set; } = default!;

    public InsertRequest(TModel model)
        => Model = model;
}

public class PostRequestHandler<T, TModel> : IRequestHandler<InsertRequest<T, TModel>, T> 
    where T : EntityBase
    where TModel : IModel<T>
{
    private readonly IUnitOfWork _unitOfWork;

    public PostRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<T> Handle(InsertRequest<T, TModel> request, CancellationToken cancellationToken)
    {
        var item = request.Model.ToEntity();

        item.CreatedAt = DateTime.Now;

        await _unitOfWork.Repository<T>().AddAsync(item, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return item;
    }
}
