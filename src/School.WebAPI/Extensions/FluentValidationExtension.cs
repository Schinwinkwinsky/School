using FluentValidation;
using School.Application.CQRS.Generics;
using School.Application.Validators;
using School.Domain.Entities;

namespace School.WebAPI.Extensions
{
    public static class FluentValidationExtension
    {
        public static void RegisterGenericValidators(this IServiceCollection services)
        {
            services.AddScoped<IValidator<AddRelatedEntitiesRequest<Teacher, KnowledgeArea>>, AddRelatedEntitiesRequestValidator<Teacher, KnowledgeArea>>();
            services.AddScoped<IValidator<RemoveRelatedEntitiesRequest<Teacher, KnowledgeArea>>, RemoveRelatedEntitiesRequestValidator<Teacher, KnowledgeArea>>();
        }
    }
}
