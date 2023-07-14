using FluentValidation;
using School.Application.Models;

namespace School.Application.Validators
{
    public class PhoneValidator : AbstractValidator<PhoneModel>
    {
        public PhoneValidator() 
        { 
            RuleFor(p => p.GlobalCode).NotEmpty();
            RuleFor(p => p.LocalCode).NotEmpty();
            RuleFor(p => p.Number).NotEmpty();
        }
    }
}
