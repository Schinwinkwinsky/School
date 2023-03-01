using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Generics
{
    public class GetByIdRequest<T> : IRequest<IQueryable<T>> 
        where T : EntityBase
    {
        public int Id { get; set; }

        public GetByIdRequest(int id)
            => Id = id;
    }

    public class GetByIdRequestHandler<T> : IRequestHandler<GetByIdRequest<T>, IQueryable<T>> where T : EntityBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetByIdRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<T>> Handle(GetByIdRequest<T> request, CancellationToken cancellationToken)
        {
            var items = _unitOfWork.Repository<T>()
                .GetAll()
                .Where(i => i.Id == request.Id
                    && i.DeletedAt == DateTime.MinValue
                    && i.DeletedBy == 0);

            if (!items.Any())
                throw new HttpRequestException($"{ typeof(T).Name } with id = { request.Id } was not found.", null, HttpStatusCode.NotFound);

            return await Task.FromResult(items);
        }
    }
}
