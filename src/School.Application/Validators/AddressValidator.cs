using FluentValidation;
using School.Application.Models;

namespace School.Application.Validators
{
    public class AddressValidator : AbstractValidator<AddressModel>
    {
        public AddressValidator()
        {
            RuleFor(a => a.Street).NotEmpty();
            RuleFor(a => a.Number).NotEmpty();
            RuleFor(a => a.District).NotEmpty();
            RuleFor(a => a.City).NotEmpty();
            RuleFor(a => a.State).NotEmpty();
            RuleFor(a => a.Country).NotEmpty();
            RuleFor(a => a.PostCode).NotEmpty();
        }
    }
}
