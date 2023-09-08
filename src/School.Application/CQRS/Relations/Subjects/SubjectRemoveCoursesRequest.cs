using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.Subjects;

public class SubjectRemoveCoursesRequest : IRequest<Subject>
{
    public Guid SubjectId { get; set; }
    public Guid[] CourseIds { get; set; } = new Guid[0];

    public SubjectRemoveCoursesRequest(Guid subjectId, Guid[] courseIds)
    {
        SubjectId = subjectId;
        CourseIds = courseIds;
    }
}

public class SubjectRemoveCoursesRequestRequestHandler : IRequestHandler<SubjectRemoveCoursesRequest, Subject>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubjectRemoveCoursesRequestRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Subject> Handle(SubjectRemoveCoursesRequest request, CancellationToken cancellationToken)
    {
        var subject = await _unitOfWork.Repository<Subject>()
            .GetAll()
            .Where(s => s.Id == request.SubjectId)
            .Include(s => s.CourseSubject)
            .FirstOrDefaultAsync(cancellationToken);

        if (subject is null)
            throw new HttpRequestException($"Subject with id = {request.SubjectId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var id in request.CourseIds)
        {
            var courseSubject = subject.CourseSubject.SingleOrDefault(cs => cs.CourseId == id && cs.SubjectId == subject.Id && !cs.IsDeleted);

            if (courseSubject is not null)
                courseSubject.DeletedAt = DateTime.Now;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return subject;
    }
}
