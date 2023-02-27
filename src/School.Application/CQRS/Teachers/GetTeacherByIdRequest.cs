using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.Teachers
{
    public class GetTeacherByIdRequest : IRequest<IQueryable<Teacher>>
    {
        public int Id { get; set; }
    }

    public class GetTeacherByIdRequestHandler : IRequestHandler<GetTeacherByIdRequest, IQueryable<Teacher>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetTeacherByIdRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<IQueryable<Teacher>> Handle(GetTeacherByIdRequest request, CancellationToken cancellationToken)
        {
            var teachers = _unitOfWork.Repository<Teacher>()
                .GetAll()
                .Where(s => s.DeletedAt == DateTime.MinValue
                    && s.DeletedBy == 0);

            if (!teachers.Any())
                throw new HttpRequestException($"Teacher with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            return await Task.FromResult(teachers);
        }
    }
}
