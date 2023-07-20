using FluentValidation;
using School.Application.Models;

namespace School.Application.Validators.SchoolClassValidators
{
    public class SchoolClassModelValidator : AbstractValidator<SchoolClassModel>
    {
        public SchoolClassModelValidator()
        {
            RuleFor(s => s.Code).NotEmpty();
            RuleFor(s => s.PeriodId).NotEmpty();
            RuleFor(s => s.SubjectId).NotEmpty();
            RuleFor(s => s.TeacherId).NotEmpty();
        }
    }
}
