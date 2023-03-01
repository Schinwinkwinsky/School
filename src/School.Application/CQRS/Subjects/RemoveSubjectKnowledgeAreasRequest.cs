using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Subjects
{
    public class RemoveSubjectKnowledgeAreasRequest : IRequest<Subject>
    {
        public int Id { get; set; }
        public IEnumerable<int> KnowledgeAreasIds { get; set; } = default!;
    }

    public class RemoveSubjectKnowledgeAreasRequestHandler : IRequestHandler<RemoveSubjectKnowledgeAreasRequest, Subject>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveSubjectKnowledgeAreasRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Subject> Handle(RemoveSubjectKnowledgeAreasRequest request, CancellationToken cancellationToken)
        {
            var subject = await _unitOfWork.Repository<Subject>()
                .GetAll()
                .Where(s => s.Id == request.Id)
                .Include(s => s.KnowledgeAreas)
                .FirstOrDefaultAsync();

            if (subject is null)
                throw new HttpRequestException($"Subject with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            if (!subject.KnowledgeAreas.Any() || !request.KnowledgeAreasIds.Any())
                return subject;

            bool isSubjectUpdated = false;

            foreach (var id in request.KnowledgeAreasIds)
            {
                var area = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(id, cancellationToken);

                if (area is not null && subject.KnowledgeAreas.Contains(area))
                {
                    subject.KnowledgeAreas.Remove(area);
                    isSubjectUpdated = true;
                }
            }

            if (isSubjectUpdated)
            {
                subject.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return subject;
        }
    }
}
