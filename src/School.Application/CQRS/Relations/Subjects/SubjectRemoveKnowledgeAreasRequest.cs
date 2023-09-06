using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.Subjects;

public class SubjectRemoveKnowledgeAreasRequest : IRequest<Subject>
{
    public Guid SubjectId { get; set; }
    public Guid[] KnowledgeAreaIds { get; set; } = new Guid[0];

    public SubjectRemoveKnowledgeAreasRequest(Guid subjectId, Guid[] knowledgeAreaIds)
    {
        SubjectId = subjectId;
        KnowledgeAreaIds = knowledgeAreaIds;
    }
}

public class SubjectRemoveKnowledgeAreasRequestHandler : IRequestHandler<SubjectRemoveKnowledgeAreasRequest, Subject>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubjectRemoveKnowledgeAreasRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Subject> Handle(SubjectRemoveKnowledgeAreasRequest request, CancellationToken cancellationToken)
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
            var knowledgeAreaSubject = subject.KnowledgeAreaSubject.SingleOrDefault(kas => kas.KnowledgeAreaId == id && kas.SubjectId == subject.Id && !kas.IsDeleted);

            if (knowledgeAreaSubject is not null)
                knowledgeAreaSubject.DeletedAt = DateTime.Now;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return subject;
    }
}
