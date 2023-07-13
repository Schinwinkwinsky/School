using FluentValidation;
using School.Application.CQRS.Generics;
using School.Application.Models;
using School.Domain.Entities;

namespace School.Application.Validators.PeriodValidators;

public class PostPeriodValidator : AbstractValidator<PostRequest<Period, PeriodModel>>
{
    public PostPeriodValidator()
    {
        RuleFor(p => p.Model.Code).NotEmpty();
    }
}
