using FluentValidation;
using Microsoft.EntityFrameworkCore;
using School.Application.CQRS.Generics;
using School.Application.Models;
using School.Domain;
using School.Domain.Entities;

namespace School.Application.Validators.PeriodValidators;

public class PostPeriodValidator : AbstractValidator<PostRequest<Period, PeriodModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public PostPeriodValidator(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

        RuleFor(p => p.Model).SetValidator(new PeriodModelValidator());

        RuleFor(p => p.Model.EndDate).GreaterThan(p => p.Model.StartDate);

        When(p => !string.IsNullOrEmpty(p.Model.Code), () =>
        {
            RuleFor(r => r).MustAsync(CheckIfThereIsAnotherPeriodWithSameCode)
                .WithMessage("There is another Period with the same Code.");
        });
    }

    private async Task<bool> CheckIfThereIsAnotherPeriodWithSameCode(PostRequest<Period, PeriodModel> request, CancellationToken cancellationToken)
    {
        return !await _unitOfWork.Repository<Period>()
            .GetAll()
            .Where(p => p.Code == request.Model.Code)
            .AnyAsync(cancellationToken);
    }
}
