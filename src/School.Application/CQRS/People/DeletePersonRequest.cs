using MediatR;
using School.Domain.Entities;
using School.Domain;
using System.Net;

namespace School.Application.CQRS.People
{
    public class DeletePersonRequest : IRequest
    {
        public int Id { get; set; }

        public DeletePersonRequest(int id)
        {
            Id = id;
        }
    }

    public class DeletePersonRequestHandler : IRequestHandler<DeletePersonRequest, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeletePersonRequest request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Repository<KnowledgeArea>().GetAsync(request.Id, cancellationToken);

            if (person == null || person.IsDeleted)
                throw new HttpRequestException($"Person with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            person.DeletedAt = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
