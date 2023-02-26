using MediatR;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.People
{
    public class GetAllPeopleRequest : IRequest<IQueryable<Person>> { }

    public class GetAllPeopleRequestHandler : IRequestHandler<GetAllPeopleRequest, IQueryable<Person>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPeopleRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<Person>> Handle(GetAllPeopleRequest request, CancellationToken cancellationToken)
        {
            var people = _unitOfWork.Repository<Person>().GetAll()
                .Where(ka => ka.DeletedAt == DateTime.MinValue
                    && ka.DeletedBy == 0);

            return await Task.FromResult(people);
        }
    }
}
