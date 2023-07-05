using MediatR;
using School.Domain.Entities;
using School.Domain;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace School.Application.CQRS.Courses
{
    public class AddCourseSubjectsRequest : IRequest<Course>
    {
        public Guid Id { get; set; }
        public IEnumerable<Guid> SubjectsIds { get; set; } = default!;
    }

    public class AddCourseSubjectsRequestHandler : IRequestHandler<AddCourseSubjectsRequest, Course>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddCourseSubjectsRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Course> Handle(AddCourseSubjectsRequest request, CancellationToken cancellationToken)
        {
            var course = await _unitOfWork.Repository<Course>()
                .GetAll()
                .Where(a => a.Id == request.Id)
                .Include(a => a.Subjects)
                .FirstOrDefaultAsync(cancellationToken);

            if (course is null)
                throw new HttpRequestException($"Course with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            if (!request.SubjectsIds.Any())
                return course;

            bool isKnowledgeAreaUpdated = false;

            foreach (var id in request.SubjectsIds)
            {
                var subject = await _unitOfWork.Repository<Subject>().GetAsync(id, cancellationToken);

                if (subject is not null)
                {
                    course.Subjects.Add(subject);
                    isKnowledgeAreaUpdated = true;
                }
            }

            if (isKnowledgeAreaUpdated)
            {
                course.UpdatedAt = DateTime.UtcNow;

                await _unitOfWork.SaveChangesAsync(cancellationToken);
            }

            return course;
        }
    }
}
