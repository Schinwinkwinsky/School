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
            var subjects = _unitOfWork.Repository<Subject>()
                .GetAll()
                .Where(s => s.DeletedAt == DateTime.MinValue
                    && s.DeletedBy == 0);

            if (!subjects.Any())
                throw new HttpRequestException($"Subject with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            return await Task.FromResult(subjects);
        }
    }
}
