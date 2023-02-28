using MediatR;
using School.Application.Interfaces;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Subjects
{
    public class PutSubjectRequest : IRequest<Subject>, IIdentifiable
    {
        public int Id { get; set; }
        public List<int> KnowledgeAreasIds { get; set; } = default!;
        public string Name { get; set; } = string.Empty;

        public Subject ToSubject()
        {
            return new Subject
            {
                Id = Id,
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

            subject = request.ToSubject();

            var areas = new List<KnowledgeArea>();

            foreach (var id in request.KnowledgeAreasIds)
            {
                var area = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(id, cancellationToken);

                if (area != null)
                    areas.Add(area);
            }

            subject.KnowledgeAreas = areas;
            subject.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return subject;
        }
    }
}
