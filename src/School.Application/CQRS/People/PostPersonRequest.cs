using MediatR;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.CQRS.People
{
    public class PostPersonRequest : IRequest<Person>
    {
        public string Name { get; set; } = default!;
        public DateTime Birth { get; set; }

        public ICollection<Address>? Addresses { get; set; }
        public ICollection<Email>? Emails { get; set; }
        public ICollection<Phone>? Phones { get; set; }

        public Person ToPerson()
        {
            return new Person
            {
                Name = Name,
                Birth = Birth,

                Addresses = Addresses ?? default!,
                Emails = Emails ?? default!,
                Phones = Phones ?? default!
            };
        }
    }

    public class PostPersonRequestHandler : IRequestHandler<PostPersonRequest, Person>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostPersonRequestHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<Person> Handle(PostPersonRequest request, CancellationToken cancellationToken)
        {
            var person = request.ToPerson();

            person.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.Repository<Person>().AddAsync(person, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return person;
        }
    }
}
