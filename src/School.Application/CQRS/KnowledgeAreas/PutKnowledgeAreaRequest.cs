using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class PutKnowledgeAreaRequest : IRequest<KnowledgeArea>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }

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
            var area = await _unitOfWork.Repository<KnowledgeArea>()
                .GetByIdAsync(request.Id, false, cancellationToken);

            if (area == null || area.IsDeleted)
                throw new HttpRequestException($"KnowledgeArea with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            area = request.ToKnowledgeArea();

            area.UpdatedAt = DateTime.Now;

            await _unitOfWork.Repository<KnowledgeArea>().UpdateAsync(area, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return area;
        }
    }
}
