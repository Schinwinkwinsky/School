using FluentValidation;
using School.Application.Models;

namespace School.Application.Validators.PersonValidators
{
    public class PersonModelValidator : AbstractValidator<PersonModel>
    {
        public PersonModelValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Birth).NotEmpty();
        }
    }
}
