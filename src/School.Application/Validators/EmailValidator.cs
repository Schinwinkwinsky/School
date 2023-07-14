using FluentValidation;
using School.Application.Models;

namespace School.Application.Validators
{
    public class EmailValidator : AbstractValidator<EmailModel>
    {
        public EmailValidator()
        {
            RuleFor(e => e.Address).NotEmpty();
        }
    }
}
