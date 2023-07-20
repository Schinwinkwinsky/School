using FluentValidation;
using School.Application.CQRS.Generics;
using School.Application.Models;
using School.Domain.Entities;

namespace School.Application.Validators.PersonValidators
{
    public class PostPersonValidator : AbstractValidator<PostRequest<Person, PersonModel>>
    {
        public PostPersonValidator() 
        {
            RuleFor(r => r.Model).SetValidator(new PersonModelValidator());

            RuleForEach(r => r.Model.Addresses).SetValidator(new AddressValidator());
            RuleForEach(r => r.Model.Emails).SetValidator(new EmailValidator());
            RuleForEach(r => r.Model.Phones).SetValidator(new PhoneValidator());
        }
    }
}
