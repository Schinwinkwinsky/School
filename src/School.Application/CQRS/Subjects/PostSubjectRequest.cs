using MediatR;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class PostSubjectRequest : IRequest<Subject>
    {
        public int KnowledgeAreaId { get; set; }
        public string Name { get; set; } = string.Empty;

        public Subject ToSubject()
        {
            return new Subject
            {
                KnowledgeAreaId = KnowledgeAreaId,
                Name = Name
            };
        }
    }

    public class PostSubjectRequestHandler : IRequestHandler<PostSubjectRequest, Subject>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostSubjectRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Subject> Handle(PostSubjectRequest request, CancellationToken cancellationToken)
        {
            var subject = request.ToSubject();

            subject.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<Subject>().AddAsync(subject, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return subject;
        }
    }
}
