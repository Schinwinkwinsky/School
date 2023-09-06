using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Relations;
using System.Net;

namespace School.Application.CQRS.Relations.Subjects;

public class SubjectAddKnowledgeAreasRequest : IRequest<Subject>
{
    public Guid SubjectId { get; set; }
    public Guid[] KnowledgeAreaIds { get; set; } = new Guid[0];

    public SubjectAddKnowledgeAreasRequest(Guid subjectId, Guid[] knowledgeAreaIds)
    {
        SubjectId = subjectId;
        KnowledgeAreaIds = knowledgeAreaIds;
    }
}

public class SubjectAddKnowledgeAreasRequestHandler : IRequestHandler<SubjectAddKnowledgeAreasRequest, Subject>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubjectAddKnowledgeAreasRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Subject> Handle(SubjectAddKnowledgeAreasRequest request, CancellationToken cancellationToken)
    {
        var subject = await _unitOfWork.Repository<Subject>()
            .GetAll()
            .Where(s => s.Id == request.SubjectId)
            .Include(s => s.KnowledgeAreaSubject)
            .FirstOrDefaultAsync(cancellationToken);

        if (subject is null)
            throw new HttpRequestException($"Subject with id = {request.SubjectId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var id in request.KnowledgeAreaIds)
        {
            var knowledgeArea = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(id, cancellationToken);

            if (knowledgeArea is not null && !subject.KnowledgeAreaSubject.Any(kas => kas.KnowledgeAreaId == knowledgeArea.Id && kas.SubjectId == subject.Id))
            {
                var knowledgeAreaSubject = new KnowledgeAreaSubject
                {
                    KnowledgeAreaId = knowledgeArea.Id,
                    SubjectId = subject.Id,
                    CreatedAt = DateTime.Now
                };

                subject.KnowledgeAreaSubject.Add(knowledgeAreaSubject);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return subject;
    }
}
