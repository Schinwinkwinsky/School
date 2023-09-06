using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.Subjects;

public class SubjectRemoveRelationsRequest : IRequest
{
    public Guid SubjectId { get; set; }

    public SubjectRemoveRelationsRequest(Guid subjectId)
    {
        SubjectId = subjectId;
    }
}

public class SubjectRemoveRelationsRequestHandler : IRequestHandler<SubjectRemoveRelationsRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubjectRemoveRelationsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task Handle(SubjectRemoveRelationsRequest request, CancellationToken cancellationToken)
    {
        var subject = await _unitOfWork.Repository<Subject>()
            .GetAll()
            .Where(s => s.Id == request.SubjectId)
            .Include(s => s.CourseSubject)
            .Include(s => s.KnowledgeAreaSubject)
            .FirstOrDefaultAsync(cancellationToken);

        if (subject is null)
            throw new HttpRequestException($"Subject with id = {request.SubjectId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var courseSubject in subject.CourseSubject)
            if (courseSubject.DeletedAt == default)
                courseSubject.DeletedAt = DateTime.Now;

        foreach (var knowledgeAreaSubject in subject.KnowledgeAreaSubject)
            if (knowledgeAreaSubject.DeletedAt == default)
                knowledgeAreaSubject.DeletedAt = DateTime.Now;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
