using FluentValidation;
using School.Application.Models;

namespace School.Application.Validators.CourseValidators
{
    public class CourseModelValidator : AbstractValidator<CourseModel>
    {
        public CourseModelValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}
