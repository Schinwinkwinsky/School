using FluentValidation;
using School.Application.CQRS.Generics;
using School.Application.Models;
using School.Domain.Entities;

namespace School.Application.Validators.KnowledgeAreaValidators
{
    public class KnowledgeAreaValidator : AbstractValidator<PostRequest<KnowledgeArea, KnowledgeAreaModel>>
    {
        public KnowledgeAreaValidator()
        {
            RuleFor(r => r.Model.Name).NotEmpty();
        }
    }
}
