using FluentValidation;
using School.Application.CQRS.Generics;
using School.Application.Models;
using School.Domain.Entities;

namespace School.Application.Validators.KnowledgeAreaValidators
{
    public class PostKnowledgeAreaValidator : AbstractValidator<PostRequest<KnowledgeArea, KnowledgeAreaModel>>
    {
        public PostKnowledgeAreaValidator()
        {
            RuleFor(r => r.Model.Name).NotEmpty();
        }
    }
}
