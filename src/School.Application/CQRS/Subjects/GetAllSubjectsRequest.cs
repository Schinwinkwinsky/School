using MediatR;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.Subjects
{
    public class GetAllSubjectsRequest : IRequest<IQueryable<Subject>> { }

    public class GetAllSubjectsRequestHandler : IRequestHandler<GetAllSubjectsRequest, IQueryable<Subject>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSubjectsRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<Subject>> Handle(GetAllSubjectsRequest request, CancellationToken cancellationToken)
        {
            var subjects = _unitOfWork.Repository<Subject>()
                .GetAll()
                .Where(s => s.DeletedAt == DateTime.MinValue
                    && s.DeletedBy == 0);

            return await Task.FromResult(subjects);
        }
    }
}
