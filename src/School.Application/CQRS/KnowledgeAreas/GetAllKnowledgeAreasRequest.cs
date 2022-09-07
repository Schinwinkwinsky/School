using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using School.Application.DTO;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class GetAllKnowledgeAreasRequest : IRequest<IQueryable<KnowledgeArea>>
    {
        public bool IncludeDeleted { get; set; } = false;
    }

    public class GetAllKnowledgeAreasRequestHandler : IRequestHandler<GetAllKnowledgeAreasRequest, IQueryable<KnowledgeArea>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllKnowledgeAreasRequestHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IQueryable<KnowledgeArea>> Handle(GetAllKnowledgeAreasRequest request, CancellationToken cancellationToken)
        {
            IQueryable<KnowledgeArea> queryable;

            if (request.IncludeDeleted)
                queryable = await _unitOfWork.Repository<KnowledgeArea>()
                    .GetAllAsync(cancellationToken: cancellationToken);
            else
                queryable = await _unitOfWork.Repository<KnowledgeArea>()
                    .GetAllAsync(predicate: k => k.DeletedAt == DateTime.MinValue
                        && k.DeletedBy == 0, cancellationToken: cancellationToken);

            return queryable;
        }
    }
}
