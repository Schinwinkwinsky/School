using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Teachers
{
    public class PostTeacherRequest : IRequest<Teacher>
    {
        public int PersonId { get; set; }
        public IEnumerable<int> KnowledgeAreasIds { get; set; } = default!;

        public Teacher ToTeacher()
        {
            return new Teacher
            {
                PersonId = PersonId
            };
        }
    }

    public class PostTeacherRequestHandler : IRequestHandler<PostTeacherRequest, Teacher>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostTeacherRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Teacher> Handle(PostTeacherRequest request, CancellationToken cancellationToken)
        {
            var teacher = request.ToTeacher();

            var personExists = await _unitOfWork.Repository<Person>().AnyAsync(p => p.Id == request.PersonId);

            if (!personExists)
                throw new HttpRequestException($"Person with id = {request.PersonId} was not found.", null, HttpStatusCode.NotFound);

            var areas = new List<KnowledgeArea>();

            foreach (var id in request.KnowledgeAreasIds)
            {
                var area = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(id, cancellationToken);

                if (area != null)
                    areas.Add(area);
            }

            teacher.CreatedAt = DateTime.UtcNow;
            teacher.KnowledgeAreas = areas;

            await _unitOfWork.Repository<Teacher>().AddAsync(teacher, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return teacher;
        }
    }
}
