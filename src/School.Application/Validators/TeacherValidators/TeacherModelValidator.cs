using FluentValidation;
using School.Application.Models;

namespace School.Application.Validators.TeacherValidators
{
    public class TeacherModelValidator : AbstractValidator<TeacherModel>
    {
        public TeacherModelValidator()
        {
            RuleFor(t => t.PersonId).NotEmpty();
        }
    }
}
