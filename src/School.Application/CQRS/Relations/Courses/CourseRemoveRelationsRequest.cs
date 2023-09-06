using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Relations.Courses;

public class CourseRemoveRelationsRequest : IRequest
{
    public Guid CourseId { get; set; }

    public CourseRemoveRelationsRequest(Guid courseId)
        => CourseId = courseId;
}

public class CourseRemoveRelationsRequestHandler : IRequestHandler<CourseRemoveRelationsRequest>
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseRemoveRelationsRequestHandler(IUnitOfWork unitOfWork)
        => _unitOfWork = unitOfWork;

    public async Task Handle(CourseRemoveRelationsRequest request, CancellationToken cancellationToken)
    {
        var course = await _unitOfWork.Repository<Course>()
            .GetAll()
            .Where(c => c.Id == request.CourseId)
            .Include(c => c.CourseSubject)
            .FirstOrDefaultAsync(cancellationToken);

        if (course is null)
            throw new HttpRequestException($"Course with id = {request.CourseId} was not found.", null, HttpStatusCode.NotFound);

        foreach (var courseSubject in course.CourseSubject)
            if (courseSubject.DeletedAt == default)
                courseSubject.DeletedAt = DateTime.Now;

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
