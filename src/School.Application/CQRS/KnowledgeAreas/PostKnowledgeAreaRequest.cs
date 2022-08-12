using MediatR;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class PostKnowledgeAreaRequest : IRequest<KnowledgeArea>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

        public KnowledgeArea ToKnowledgeArea()
        {
            return new KnowledgeArea
            {
                Name = Name,
                Description = Description
            };
        }
    }

    public class PostKnowledgeAreaRequestHandler : IRequestHandler<PostKnowledgeAreaRequest, KnowledgeArea>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostKnowledgeAreaRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<KnowledgeArea> Handle(PostKnowledgeAreaRequest request, CancellationToken cancellationToken)
        {
            var knowledgeArea = request.ToKnowledgeArea();

            knowledgeArea.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<KnowledgeArea>().AddAsync(knowledgeArea, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return knowledgeArea;
        }
    }
}
