using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Relations;
using System.Net;

namespace School.Application.CQRS.Relations.KnowledgeAreas;

public class KnowledgeAreaAddSubjectsRequest : IRequest<KnowledgeArea>
{
    public Guid KnowledgeAreaId { get; set; }
    public Guid[] SubjectIds { get; set; } = new Guid[0];

    public KnowledgeAreaAddSubjectsRequest(Guid knowledgeAreaId, Guid[] subjectIds)
    {
        KnowledgeAreaId = knowledgeAreaId;
        SubjectIds = subjectIds;
    }
}

public class KnowledgeAreaAddSubjectsRequestHandler : IRequestHandler<KnowledgeAreaAddSubjectsRequest, KnowledgeArea>
{
    private readonly IUnitOfWork _unitOfWork;

    public KnowledgeAreaAddSubjectsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<KnowledgeArea> Handle(KnowledgeAreaAddSubjectsRequest request, CancellationToken cancellationToken)
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
            var subject = await _unitOfWork.Repository<Subject>().GetAsync(id, cancellationToken);

            if (subject is not null && !knowledgeArea.KnowledgeAreaSubject.Any(kas => kas.KnowledgeAreaId == knowledgeArea.Id && kas.SubjectId == subject.Id))
            {
                var knowledgeAreaSubject = new KnowledgeAreaSubject
                {
                    KnowledgeAreaId = knowledgeArea.Id,
                    SubjectId = subject.Id,
                    CreatedAt = DateTime.Now
                };

                knowledgeArea.KnowledgeAreaSubject.Add(knowledgeAreaSubject);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return knowledgeArea;
    }
}
