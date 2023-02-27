using MediatR;
using School.Domain.Entities;
using School.Domain;
using System.Net;

namespace School.Application.CQRS.Teachers
{
    public class DeleteTeacherRequest : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTeacherRequestHandler : IRequestHandler<DeleteTeacherRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTeacherRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteTeacherRequest request, CancellationToken cancellationToken)
        {
            var teacher = await _unitOfWork.Repository<Teacher>().GetAsync(request.Id, cancellationToken);

            if (teacher == null || teacher.IsDeleted)
                throw new HttpRequestException($"Teacher with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            teacher.DeletedAt = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
