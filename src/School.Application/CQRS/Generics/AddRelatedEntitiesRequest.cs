using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;
using System.Reflection;

namespace School.Application.CQRS.Generics;

public class AddRelatedEntitiesRequest<T, TRelated> : IRequest<T> 
    where T : EntityBase
    where TRelated : EntityBase
{
    public AddRelatedEntitiesRequest(Guid id, string propertyName, IEnumerable<Guid> itemsIds)
    {
        Id = id;
        PropertyName = propertyName;
        ItemsIds = itemsIds;
    }

    public Guid Id { get; set; }
    public string PropertyName { get; set; } = default!;
    public IEnumerable<Guid> ItemsIds { get; set; } = default!;
}

public class AddRelatedEntitiesHandler<T, TRelated> : IRequestHandler<AddRelatedEntitiesRequest<T, TRelated>, T>
    where T : EntityBase
    where TRelated : EntityBase
{
    private readonly IUnitOfWork _unitOfWork;

    public AddRelatedEntitiesHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<T> Handle(AddRelatedEntitiesRequest<T, TRelated> request, CancellationToken cancellationToken)
    {
        var entity = await _unitOfWork.Repository<T>()
            .GetAll()
            .Where(e => e.Id == request.Id)
            .Include(request.PropertyName)
            .FirstOrDefaultAsync(cancellationToken);

        if (entity is null)
            throw new HttpRequestException($"{typeof(T).Name} with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

        PropertyInfo property = typeof(T).GetProperty(request.PropertyName)!;

        foreach (var id in request.ItemsIds)
        {
            var item = await _unitOfWork.Repository<TRelated>().GetAsync(id, cancellationToken);

            if (item is not null)
            {
                var method = property.PropertyType.GetMethod("Add");
                method?.Invoke(property.GetValue(entity), new object[] { item });
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);        

        return entity;
    }
}
