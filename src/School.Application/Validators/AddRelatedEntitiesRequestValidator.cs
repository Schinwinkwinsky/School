using FluentValidation;
using School.Application.CQRS.Generics;
using School.Domain.Entities;

namespace School.Application.Validators
{
    public class AddRelatedEntitiesRequestValidator<T, TRelated> : AbstractValidator<AddRelatedEntitiesRequest<T, TRelated>> 
        where T : EntityBase
        where TRelated : EntityBase
    {
        public AddRelatedEntitiesRequestValidator()
        {
            RuleFor(r => r.ItemsIds).NotEmpty();
        }
    }
}
