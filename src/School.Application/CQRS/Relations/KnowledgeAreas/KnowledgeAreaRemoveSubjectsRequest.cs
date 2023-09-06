using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.KnowledgeAreas;

public class KnowledgeAreaRemoveSubjectsRequest : IRequest<KnowledgeArea>
{
    public Guid KnowledgeAreaId { get; set; }
    public Guid[] SubjectIds { get; set; } = new Guid[0];

    public KnowledgeAreaRemoveSubjectsRequest(Guid knowledgeAreaId, Guid[] subjectIds)
    {
        KnowledgeAreaId = knowledgeAreaId;
        SubjectIds = subjectIds;
    }
}

public class KnowledgeAreaRemoveSubjectsRequestHandler : IRequestHandler<KnowledgeAreaRemoveSubjectsRequest, KnowledgeArea>
{
    private readonly IUnitOfWork _unitOfWork;

    public KnowledgeAreaRemoveSubjectsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<KnowledgeArea> Handle(KnowledgeAreaRemoveSubjectsRequest request, CancellationToken cancellationToken)
    {
        var knowledgeArea = await _unitOfWork.Repository<KnowledgeArea>()
            .GetAll()
            .Where(ka => ka.Id == request.KnowledgeAreaId)
            .Include(ka => ka.KnowledgeAreaSubject)
            .FirstOrDefaultAsync(cancellationToken);

        if (knowledgeArea is null)
            throw new HttpRequestException($"KnowledgeArea with id = { request.KnowledgeAreaId } was not found.", null, HttpStatusCode.NotFound);

        foreach (var id in request.SubjectIds)
        {
            var knowledgeAreaSubject = knowledgeArea.KnowledgeAreaSubject.SingleOrDefault(kas => kas.KnowledgeAreaId == knowledgeArea.Id && kas.SubjectId == id && !kas.IsDeleted);

            if (knowledgeAreaSubject is not null)
                knowledgeAreaSubject.DeletedAt = DateTime.Now;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return knowledgeArea;
    }
}
