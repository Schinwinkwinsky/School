using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.People
{
    public class GetPersonByIdRequest : IRequest<IQueryable<Person>>
    {
        public int Id { get; set; }
    }

    public class GetPersonByIdRequestHandler : IRequestHandler<GetPersonByIdRequest, IQueryable<Person>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPersonByIdRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<Person>> Handle(GetPersonByIdRequest request, CancellationToken cancellationToken)
        {
            var people = _unitOfWork.Repository<Person>()
                .GetAll()
                .Where(ka => ka.Id == request.Id
                    && ka.DeletedAt == DateTime.MinValue
                    && ka.DeletedBy == 0);

            if (!people.Any())
                throw new HttpRequestException($"Person with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            return await Task.FromResult(people);
        }
    }
}
