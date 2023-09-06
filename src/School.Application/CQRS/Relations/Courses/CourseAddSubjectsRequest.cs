using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using School.Domain.Relations;
using System.Net;

namespace School.Application.CQRS.Relations.Courses;

public class CourseAddSubjectsRequest : IRequest<Course>
{
    public Guid CourseId { get; set; }
    public Guid[] SubjectIds { get; set; } = new Guid[0];

    public CourseAddSubjectsRequest(Guid courseId, Guid[] subjectIds)
    {
        CourseId = courseId;
        SubjectIds = subjectIds;
    }
}

public class CourseAddSubjectsRequestHandler : IRequestHandler<CourseAddSubjectsRequest, Course>
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseAddSubjectsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Course> Handle(CourseAddSubjectsRequest request, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.Repository<Course>()
            .GetAll()
            .Where(c => c.Id == request.CourseId)
            .Include(c => c.CourseSubject)
            .FirstOrDefaultAsync(cancellationToken);

        if (course is null)
            throw new HttpRequestException($"Course with id = {request.CourseId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var id in request.SubjectIds)
        {
            var subject = await _unitOfWork.Repository<Subject>().GetAsync(id, cancellationToken);
            
            if (subject is not null && !course.CourseSubject.Any(cs => cs.CourseId == course.Id && cs.SubjectId == subject.Id))
            {
                var courseSubject = new CourseSubject
                {
                    CourseId = course.Id,
                    SubjectId = subject.Id,
                    CreatedAt = DateTime.Now
                };

                course.CourseSubject.Add(courseSubject);
            }
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return course;
    }
}
