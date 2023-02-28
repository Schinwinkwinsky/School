using MediatR;
using School.Application.Interfaces;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Teachers
{
    public class PutTeacherRequest : IRequest<Teacher>, IIdentifiable
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public IEnumerable<int> KnowledgeAreasIds { get; set; } = default!;

        public Teacher ToTeacher()
        {
            return new Teacher
            {
                Id = Id,
                PersonId = PersonId
            };
        }
    }

    public class PutTeacherRequestHandler : IRequestHandler<PutTeacherRequest, Teacher>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PutTeacherRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Teacher> Handle(PutTeacherRequest request, CancellationToken cancellationToken)
        {
            var teacher = await _unitOfWork.Repository<Teacher>().GetAsync(request.Id, cancellationToken);

            if (teacher == null || teacher.IsDeleted)
                throw new HttpRequestException($"Teacher with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            teacher = request.ToTeacher();

            var areas = new List<KnowledgeArea>();

            foreach (var id in request.KnowledgeAreasIds)
            {
                var area = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(id, cancellationToken);

                if (area != null)
                    areas.Add(area);
            }

            teacher.KnowledgeAreas = areas;
            teacher.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return teacher;
        }
    }
}
