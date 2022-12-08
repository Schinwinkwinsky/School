using MediatR;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class GetAllKnowledgeAreasRequest : IRequest<IQueryable<KnowledgeArea>> { }

    public class GetAllKnowledgeAreasRequestHandler : IRequestHandler<GetAllKnowledgeAreasRequest, IQueryable<KnowledgeArea>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllKnowledgeAreasRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<KnowledgeArea>> Handle(GetAllKnowledgeAreasRequest request, CancellationToken cancellationToken)
        {
            var areas = _unitOfWork.Repository<KnowledgeArea>().GetAll()
                .Where(ka => ka.DeletedAt == DateTime.MinValue
                    && ka.DeletedBy == 0);

            return await Task.FromResult(areas);
        }
    }
}
