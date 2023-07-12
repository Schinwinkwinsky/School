using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Generics
{
    public class DeleteRequest<T> : IRequest
        where T : EntityBase
    {
        public Guid Id { get; set; }

        public DeleteRequest(Guid id)
            => Id = id;
    }

    public class DeleteRequestHandler<T> : IRequestHandler<DeleteRequest<T>>
        where T : EntityBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task Handle(DeleteRequest<T> request, CancellationToken cancellationToken)
        {
            var item = await _unitOfWork.Repository<T>().GetAsync(request.Id, cancellationToken);

            if (item is null || item.IsDeleted)
                throw new HttpRequestException($"{ typeof(T).Name } with id = { request.Id } was not found.", null, HttpStatusCode.NotFound);

            item.DeletedAt = DateTime.Now;

            await _unitOfWork.SaveChangesAsync(cancellationToken);            
        }
    }
}
