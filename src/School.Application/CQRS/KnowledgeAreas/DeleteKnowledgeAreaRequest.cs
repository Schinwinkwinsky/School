using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class DeleteKnowledgeAreaRequest : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteKnowledgeAreaRequestHandler : IRequestHandler<DeleteKnowledgeAreaRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteKnowledgeAreaRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteKnowledgeAreaRequest request, CancellationToken cancellationToken)
        {
            var area = await _unitOfWork.Repository<KnowledgeArea>().GetByIdAsync(request.Id, false, cancellationToken);

            if (area == null || area.DeletedAt != DateTime.MinValue)
                throw new HttpRequestException($"KnowledgeArea with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            area.DeletedAt = DateTime.Now;

            await _unitOfWork.Repository<KnowledgeArea>().UpdateAsync(area, cancellationToken);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
