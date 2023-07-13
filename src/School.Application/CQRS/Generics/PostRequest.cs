using MediatR;
using School.Application.Models;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.Generics;

public class PostRequest<T, TModel> : IRequest<T> 
    where T : EntityBase
    where TModel : IModel<T>
{
    public TModel Model { get; set; } = default!;

    public PostRequest(TModel model)
        => Model = model;
}

public class PostRequestHandler<T, TModel> : IRequestHandler<PostRequest<T, TModel>, T> 
    where T : EntityBase
    where TModel : IModel<T>
{
    private readonly IUnitOfWork _unitOfWork;

    public PostRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<T> Handle(PostRequest<T, TModel> request, CancellationToken cancellationToken)
    {
        var item = request.Model.ToEntity();

        item.CreatedAt = DateTime.UtcNow;

        await _unitOfWork.Repository<T>().AddAsync(item, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return item;
    }
}
