using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Generics
{
    public class AddRelatedEntities<T> : IRequest<T> 
        where T : EntityBase
    {
        public Guid Id { get; set; }
        public string PropertyName { get; set; } = default!;
        public IEnumerable<Guid> ItemsIds { get; set; } = default!;
    }

    public class AddRelatedEntitiesHandler<T> : IRequestHandler<AddRelatedEntities<T>, T>
        where T : EntityBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddRelatedEntitiesHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<T> Handle(AddRelatedEntities<T> request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Repository<T>()
                .GetAll()
                .Where(e => e.Id == request.Id)
                .Include(request.PropertyName)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity is null)
                throw new HttpRequestException($"{typeof(T).Name} with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            bool isItemUpdated = false;

            foreach (var id in request.ItemsIds)
            {
                var property = entity.GetType().GetProperty(request.PropertyName);

                if (property is not null)
                {
                    var type = property.GetType();

                    var value = property.GetValue(this, null);
                }                

                var relatedItem = await _unitOfWork.Repository<Subject>().GetAsync(id, cancellationToken);

                //if (subject is not null)
                //{
                //    list.Add(subject);
                //    isItemUpdated = true;
                //}
            }

            if (isItemUpdated)
            {
                entity.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return entity;
        }
    }
}
