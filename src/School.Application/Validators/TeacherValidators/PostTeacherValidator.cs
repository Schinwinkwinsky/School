using FluentValidation;
using School.Application.CQRS.Generics;
using School.Application.Models;
using School.Domain.Entities;

namespace School.Application.Validators.TeacherValidators;

public class PostTeacherValidator : AbstractValidator<PostRequest<Teacher, TeacherModel>>
{
    public PostTeacherValidator()
    {
        RuleFor(r => r.Model).SetValidator(new TeacherModelValidator());
    }
}
