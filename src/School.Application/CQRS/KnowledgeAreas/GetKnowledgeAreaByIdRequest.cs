using MediatR;
using School.Domain;
using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.CQRS.KnowledgeAreas
{
    public class GetKnowledgeAreaByIdRequest : IRequest<IQueryable<KnowledgeArea>>
    {
        public int Id { get; set; }
        public bool IncludeDeleted { get; set; } = false;
    }

    public class GetKnowledgeAreaByIdRequestHandler : IRequestHandler<GetKnowledgeAreaByIdRequest, IQueryable<KnowledgeArea>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetKnowledgeAreaByIdRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<KnowledgeArea>> Handle(GetKnowledgeAreaByIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<KnowledgeArea> queryable;

            if (request.IncludeDeleted)
                queryable = await _unitOfWork.Repository<KnowledgeArea>()
                    .GetAllAsync(predicate: k => k.Id == request.Id, cancellationToken: cancellationToken);
            else
                queryable = await _unitOfWork.Repository<KnowledgeArea>()
                    .GetAllAsync(predicate: k => k.Id == request.Id 
                        && (k.DeletedAt == DateTime.MinValue
                            && k.DeletedBy == 0), cancellationToken: cancellationToken);

            if (!queryable.Any())
                throw new HttpRequestException("Item not found.", null, HttpStatusCode.NotFound);

            return queryable;
        }
    }
}
