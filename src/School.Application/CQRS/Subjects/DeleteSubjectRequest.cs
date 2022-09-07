using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Subjects
{
    public class DeleteSubjectRequest : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteSubjectRequestHandler : IRequestHandler<DeleteSubjectRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSubjectRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteSubjectRequest request, CancellationToken cancellationToken)
        {
            var subject = await _unitOfWork.Repository<Subject>().GetByIdAsync(request.Id, false, cancellationToken);

            if (subject == null || subject.IsDeleted)
                throw new HttpRequestException($"Subject with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            subject.DeletedAt = DateTime.Now;

            await _unitOfWork.Repository<Subject>().UpdateAsync(subject, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
