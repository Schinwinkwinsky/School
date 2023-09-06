using FluentValidation;
using School.Application.CQRS.Generics;
using School.Application.Models;
using School.Domain.Entities;

namespace School.Application.Validators.KnowledgeAreaValidators
{
    public class PostKnowledgeAreaValidator : AbstractValidator<InsertRequest<KnowledgeArea, KnowledgeAreaModel>>
    {
        public PostKnowledgeAreaValidator()
        {
            RuleFor(r => r.Model).SetValidator(new KnowledgeAreaModelValidator());
        }
    }
}
