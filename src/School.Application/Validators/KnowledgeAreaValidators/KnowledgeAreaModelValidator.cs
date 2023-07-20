using FluentValidation;
using School.Application.Models;

namespace School.Application.Validators.KnowledgeAreaValidators
{
    public class KnowledgeAreaModelValidator : AbstractValidator<KnowledgeAreaModel>
    {
        public KnowledgeAreaModelValidator()
        {
            RuleFor(k => k.Name).NotEmpty();
        }
    }
}
