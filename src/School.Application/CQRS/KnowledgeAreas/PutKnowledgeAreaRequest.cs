using MediatR;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class PutKnowledgeAreaRequest : IRequest<KnowledgeArea>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public bool IncludeDeleted { get; set; } = false;

        public KnowledgeArea ToKnowledgeArea()
        {
            return new KnowledgeArea
            {
                Id = Id,
                Name = Name,
                Description = Description,
            };
        }
    }

    public class PutKnowledgeAreaRequestHandler : IRequestHandler<PutKnowledgeAreaRequest, KnowledgeArea>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PutKnowledgeAreaRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<KnowledgeArea> Handle(PutKnowledgeAreaRequest request, CancellationToken cancellationToken)
        {
            var area = await _unitOfWork.Repository<KnowledgeArea>().GetByIdAsync(request.Id, false, cancellationToken);

            if ((area == null)
                || (!request.IncludeDeleted && area.DeletedAt != DateTime.MinValue))
                throw new KeyNotFoundException($"KnowledgeArea with id = {request.Id} was not found.");

            area = request.ToKnowledgeArea();

            area.UpdatedAt = DateTime.Now;

            await _unitOfWork.Repository<KnowledgeArea>().UpdateAsync(area, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return area;
        }
    }
}
