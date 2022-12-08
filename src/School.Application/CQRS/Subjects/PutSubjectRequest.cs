using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Subjects
{
    public class PutSubjectRequest : IRequest<Subject>
    {
        public int Id { get; set; }
        public int KnowledgeAreaId { get; set; }
        public string Name { get; set; } = string.Empty;

        public Subject ToSubject()
        {
            return new Subject
            {
                Id = Id,
                KnowledgeAreaId = KnowledgeAreaId,
                Name = Name
            };
        }
    }

    public class PutSubjectRequestHandler : IRequestHandler<PutSubjectRequest, Subject>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PutSubjectRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Subject> Handle(PutSubjectRequest request, CancellationToken cancellationToken)
        {
            var subject = await _unitOfWork.Repository<Subject>().GetAsync(request.Id, cancellationToken);

            if (subject == null || subject.IsDeleted)
                throw new HttpRequestException($"Subject with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            var area = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(request.KnowledgeAreaId, cancellationToken);

            if (area == null || area.IsDeleted)
                throw new HttpRequestException($"KnowledgeArea with id = {request.KnowledgeAreaId} was not found.", null, HttpStatusCode.NotFound);

            subject = request.ToSubject();

            subject.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return subject;
        }
    }
}
