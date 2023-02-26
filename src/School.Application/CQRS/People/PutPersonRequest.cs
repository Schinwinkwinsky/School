using MediatR;
using School.Domain;
using School.Domain.Entities;
using System.Net;

namespace School.Application.CQRS.People
{
    public class PutPersonRequest : IRequest<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime Birth { get; set; }

        public ICollection<Address>? Addresses { get; set; }
        public ICollection<Email>? Emails { get; set; }
        public ICollection<Phone>? Phones { get; set; }

        public Person ToPerson()
        {
            return new Person
            {
                Id = Id,
                Name = Name,
                Birth = Birth,

                Addresses = Addresses ?? default!,
                Emails = Emails ?? default!,
                Phones = Phones ?? default!
            };
        }
    }

    public class PutPersonRequestHandler : IRequestHandler<PutPersonRequest, Person>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PutPersonRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Person> Handle(PutPersonRequest request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.Repository<Person>()
                .GetAsync(request.Id, cancellationToken);

            if (person == null || person.IsDeleted)
                throw new HttpRequestException($"Person with id = {request.Id} was not found.", null, HttpStatusCode.NotFound);

            person = request.ToPerson();

            person.UpdatedAt = DateTime.Now;

            await _unitOfWork.SaveChangesAsync();

            return person;
        }
    }
}
