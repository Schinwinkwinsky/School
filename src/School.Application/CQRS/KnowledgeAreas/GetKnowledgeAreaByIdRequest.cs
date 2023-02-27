using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class GetKnowledgeAreaByIdRequest : IRequest<IQueryable<KnowledgeArea>>
    {
        public int Id { get; set; }

        public GetKnowledgeAreaByIdRequest(int id)
        {
            Id = id;
        }
    }

    public class GetKnowledgeAreaByIdRequestHandler : IRequestHandler<GetKnowledgeAreaByIdRequest, IQueryable<KnowledgeArea>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetKnowledgeAreaByIdRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<KnowledgeArea>> Handle(GetKnowledgeAreaByIdRequest request, CancellationToken cancellationToken)
        {
            var areas = _unitOfWork.Repository<KnowledgeArea>()
                .GetAll()
                .Where(ka => ka.Id == request.Id
                    && ka.DeletedAt == DateTime.MinValue
                    && ka.DeletedBy == 0);

            if (!areas.Any())
                throw new HttpRequestException($"KnowledgeArea with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            return await Task.FromResult(areas);
        }
    }
}
