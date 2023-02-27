using MediatR;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.Teachers
{
    public class GetAllTeachersRequest : IRequest<IQueryable<Teacher>> { }

    public class GetAllTeachersRequestHandler : IRequestHandler<GetAllTeachersRequest, IQueryable<Teacher>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllTeachersRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<Teacher>> Handle(GetAllTeachersRequest request, CancellationToken cancellationToken)
        {
            var teachers = _unitOfWork.Repository<Teacher>()
                .GetAll()
                .Where(s => s.DeletedAt == DateTime.MinValue
                    && s.DeletedBy == 0);

            return await Task.FromResult(teachers);
        }
    }
}
