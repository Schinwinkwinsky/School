using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class PostSubjectRequest : IRequest<Subject>
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<int> KnowledgeAreasIds { get; set; } = default!;

        public Subject ToSubject()
        {
            return new Subject
            {
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

            var areas = new List<KnowledgeArea>();

            foreach (var id in request.KnowledgeAreasIds)
            {
                var area = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(id, cancellationToken);

                if (area != null)
                    areas.Add(area);
            }

            if (areas.Count == 0)
                throw new HttpRequestException("KnowledgeArea ids are invalid or empty. It's not possible to add a Subject with no KnowledgeArea.",
                    null, HttpStatusCode.BadRequest);

            subject.CreatedAt = DateTime.UtcNow;
            subject.KnowledgeAreas = areas;

            await _unitOfWork.Repository<Subject>().AddAsync(subject, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return subject;
        }
    }
}
