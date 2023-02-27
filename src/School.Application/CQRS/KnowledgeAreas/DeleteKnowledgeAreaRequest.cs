using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class DeleteKnowledgeAreaRequest : IRequest
    {
        public int Id { get; set; }

        public DeleteKnowledgeAreaRequest(int id)
        {
            Id = id;
        }
    }

    public class DeleteKnowledgeAreaRequestHandler : IRequestHandler<DeleteKnowledgeAreaRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteKnowledgeAreaRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteKnowledgeAreaRequest request, CancellationToken cancellationToken)
        {
            var area = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(request.Id, cancellationToken);

            if (area == null || area.IsDeleted)
                throw new HttpRequestException($"KnowledgeArea with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            area.DeletedAt = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
