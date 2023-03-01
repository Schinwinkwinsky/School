using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class AddKnowledgeAreaSubjectsRequest : IRequest<KnowledgeArea>
    {
        public int Id { get; set; }
        public IEnumerable<int> SubjectsIds { get; set; } = default!;
    }

    public class AddKnowledgeAreaSubjectsRequestHandler : IRequestHandler<AddKnowledgeAreaSubjectsRequest, KnowledgeArea>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddKnowledgeAreaSubjectsRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<KnowledgeArea> Handle(AddKnowledgeAreaSubjectsRequest request, CancellationToken cancellationToken)
        {
            var area = await _unitOfWork.Repository<KnowledgeArea>()
                .GetAll()
                .Where(a => a.Id == request.Id)
                .Include(a => a.Subjects)
                .FirstOrDefaultAsync();

            if (area is null)
                throw new HttpRequestException($"KnowledgeArea with id = { request.Id } was not found.", null, HttpStatusCode.NotFound);

            if (!request.SubjectsIds.Any())
                return area;

            bool isKnowledgeAreaUpdated = false;

            foreach (var id in request.SubjectsIds)
            {
                var subject = await _unitOfWork.Repository<Subject>().GetAsync(id, cancellationToken);

                if (subject is not null)
                {
                    area.Subjects.Add(subject);
                    isKnowledgeAreaUpdated = true;
                }
            }

            if (isKnowledgeAreaUpdated)
            {
                area.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }            

            return area;
        }
    }
}
