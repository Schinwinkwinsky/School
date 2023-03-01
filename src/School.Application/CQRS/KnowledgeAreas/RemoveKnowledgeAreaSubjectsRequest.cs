using MediatR;
using School.Domain.Entities;
using School.Domain;
using System.Collections.ObjectModel;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class RemoveKnowledgeAreaSubjectsRequest : IRequest<KnowledgeArea>
    {
        public int Id { get; set; }
        public IEnumerable<int> SubjectsIds { get; set; } = default!;
    }

    public class RemoveKnowledgeAreaSubjectsRequestHandler : IRequestHandler<RemoveKnowledgeAreaSubjectsRequest, KnowledgeArea>
    {
        private readonly IUnitOfWork _unitOfWork;

        public RemoveKnowledgeAreaSubjectsRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<KnowledgeArea> Handle(RemoveKnowledgeAreaSubjectsRequest request, CancellationToken cancellationToken)
        {
            var area = await _unitOfWork.Repository<KnowledgeArea>()
                .GetAll()
                .Where(a => a.Id == request.Id)
                .Include(a => a.Subjects)
                .FirstOrDefaultAsync();

            if (area is null)
                throw new HttpRequestException($"KnowledgeArea with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            if (!area.Subjects.Any() || !request.SubjectsIds.Any())
                return area;

            area.Subjects ??= new Collection<Subject>();

            bool isAreaUpdated = false;

            foreach (var id in request.SubjectsIds)
            {
                var subject = await _unitOfWork.Repository<Subject>().GetAsync(id, cancellationToken);

                if (subject is not null && area.Subjects.Contains(subject))
                {
                    area.Subjects.Remove(subject);
                    isAreaUpdated = true;
                }
            }

            if (isAreaUpdated)
            {
                area.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }                

            return area;
        }
    }
}
