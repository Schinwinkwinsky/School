using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.Courses;

public class CourseRemoveSubjectsRequest : IRequest<Course>
{
    public Guid CourseId { get; set; }
    public Guid[] SubjectIds { get; set; } = new Guid[0];

    public CourseRemoveSubjectsRequest(Guid courseId, Guid[] subjectIds)
    {
        CourseId = courseId;
        SubjectIds = subjectIds;
    }
}

public class CourseRemoveSubjectsRequestHandler : IRequestHandler<CourseRemoveSubjectsRequest, Course>
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseRemoveSubjectsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task<Course> Handle(CourseRemoveSubjectsRequest request, CancellationToken cancellationToken)
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
            var courseSubject = course.CourseSubject.SingleOrDefault(cs => cs.CourseId == course.Id && cs.SubjectId == id && !cs.IsDeleted);

            if (courseSubject is not null)
                courseSubject.DeletedAt = DateTime.Now;
        }

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return course;
    }
}
