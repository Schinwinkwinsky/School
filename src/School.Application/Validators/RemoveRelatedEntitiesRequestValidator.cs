using FluentValidation;
using School.Application.CQRS.Generics;
using School.Domain.Entities;

namespace School.Application.Validators
{
    public class RemoveRelatedEntitiesRequestValidator<T, TR> : AbstractValidator<RemoveRelatedEntitiesRequest<T, TR>>
        where T : EntityBase
        where TR : EntityBase
    {
        public RemoveRelatedEntitiesRequestValidator()
        {
            RuleFor(r => r.ItemsIds).NotEmpty();
        }
    }
}
