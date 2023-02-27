using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Subjects
{
    public class DeleteSubjectRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteSubjectRequest(int id)
        {
            Id = id;
        }
    }

    public class DeleteSubjectRequestHandler : IRequestHandler<DeleteSubjectRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSubjectRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteSubjectRequest request, CancellationToken cancellationToken)
        {
            var subject = await _unitOfWork.Repository<Subject>().GetAsync(request.Id, cancellationToken);

            if (subject == null || subject.IsDeleted)
                throw new HttpRequestException($"Subject with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            subject.DeletedAt = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
