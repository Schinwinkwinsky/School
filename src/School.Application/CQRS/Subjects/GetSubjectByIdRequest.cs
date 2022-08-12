using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Subjects
{
    public class GetSubjectByIdRequest : IRequest<IQueryable<Subject>>
    {
        public int Id { get; set; }
        public bool IncludeDeleted { get; set; } = false;
    }

    public class GetSubjectByIdRequestHandler : IRequestHandler<GetSubjectByIdRequest, IQueryable<Subject>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSubjectByIdRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<Subject>> Handle(GetSubjectByIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Subject> queryable;

            if (request.IncludeDeleted)
                queryable = await _unitOfWork.Repository<Subject>()
                    .GetAllAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            else
                queryable = await _unitOfWork.Repository<Subject>()
                    .GetAllAsync(predicate: k => k.Id == request.Id
                        && (k.DeletedAt == DateTime.MinValue
                            && k.DeletedBy == 0), cancellationToken: cancellationToken);

            if (!queryable.Any())
                throw new HttpRequestException("Item not found.", null, HttpStatusCode.NotFound);

            return queryable;
        }
    }
}
