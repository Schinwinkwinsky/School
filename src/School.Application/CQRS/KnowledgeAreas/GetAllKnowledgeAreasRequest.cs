using AutoMapper;
using MediatR;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class GetAllKnowledgeAreasRequest : IRequest<IQueryable<KnowledgeArea>> { }

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
            return await _unitOfWork.Repository<KnowledgeArea>()
                .GetAllAsync(predicate: k => k.DeletedAt == DateTime.MinValue
                    && k.DeletedBy == 0, cancellationToken: cancellationToken); ;
        }
    }
}
