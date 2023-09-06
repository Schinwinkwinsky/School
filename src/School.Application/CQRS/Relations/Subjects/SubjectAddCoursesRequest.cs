using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Relations;
using System.Net;

namespace School.Application.CQRS.Relations.Subjects;

public class SubjectAddCoursesRequest : IRequest<Subject>
{
    public Guid SubjectId { get; set; }
    public Guid[] CourseIds { get; set; } = new Guid[0];

    public SubjectAddCoursesRequest(Guid subjectId, Guid[] courseIds)
    {
        SubjectId = subjectId;
        CourseIds = courseIds;
    }
}

public class SubjectAddCoursesRequestHandler : IRequestHandler<SubjectAddCoursesRequest, Subject>
{
    private readonly IUnitOfWork _unitOfWork;

    public SubjectAddCoursesRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Subject> Handle(SubjectAddCoursesRequest request, CancellationToken cancellationToken)
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
            var course = await _unitOfWork.Repository<Course>().GetAsync(id, cancellationToken);

            if (course is not null && !subject.CourseSubject.Any(cs => cs.CourseId == course.Id && cs.SubjectId == subject.Id))
            {
                var courseSubject = new CourseSubject
                {
                    CourseId = course.Id,
                    SubjectId = subject.Id,
                    CreatedAt = DateTime.Now
                };

                subject.CourseSubject.Add(courseSubject);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return subject;
    }
}
