using FluentValidation;
using School.Application.Models;

namespace School.Application.Validators.PeriodValidators
{
    public class PeriodModelValidator : AbstractValidator<PeriodModel>
    {
        public PeriodModelValidator()
        {
            RuleFor(p => p.Code).NotEmpty();
            RuleFor(p => p.StartDate).NotEmpty();
            RuleFor(p => p.EndDate).NotEmpty();
        }
    }
}
