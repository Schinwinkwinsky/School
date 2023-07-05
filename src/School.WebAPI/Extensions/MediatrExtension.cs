using MediatR;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;

namespace School.WebAPI.Extensions
{
    public static class MediatrExtension
    {
        public static void RegiesterMediatrHandlers(this IServiceCollection services)
        {
            // KnowledgeArea
            services.AddTransient(typeof(IRequestHandler<GetAllRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>), typeof(GetAllRequestHandler<KnowledgeArea>));
            services.AddTransient(typeof(IRequestHandler<GetByIdRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>), typeof(GetByIdRequestHandler<KnowledgeArea>));
            services.AddTransient(typeof(IRequestHandler<PostRequest<KnowledgeArea, KnowledgeAreaModel>, KnowledgeArea>), typeof(PostRequestHandler<KnowledgeArea, KnowledgeAreaModel>));
            services.AddTransient(typeof(IRequestHandler<PutRequest<KnowledgeArea, KnowledgeAreaDto>, KnowledgeArea>), typeof(PutRequestHandler<KnowledgeArea, KnowledgeAreaDto>));
            services.AddTransient(typeof(IRequestHandler<DeleteRequest<KnowledgeArea>, Unit>), typeof(DeleteRequestHandler<KnowledgeArea>));
            services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<KnowledgeArea, Subject>, KnowledgeArea>), typeof(AddRelatedEntitiesHandler<KnowledgeArea, Subject>));
            services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<KnowledgeArea, Subject>, KnowledgeArea>), typeof(RemoveRelatedEntitiesHandler<KnowledgeArea, Subject>));

            // Subject
            services.AddTransient(typeof(IRequestHandler<GetAllRequest<Subject>, IQueryable<Subject>>), typeof(GetAllRequestHandler<Subject>));
            services.AddTransient(typeof(IRequestHandler<GetByIdRequest<Subject>, IQueryable<Subject>>), typeof(GetByIdRequestHandler<Subject>));
            services.AddTransient(typeof(IRequestHandler<PostRequest<Subject, SubjectModel>, Subject>), typeof(PostRequestHandler<Subject, SubjectModel>));
            services.AddTransient(typeof(IRequestHandler<PutRequest<Subject, SubjectDto>, Subject>), typeof(PutRequestHandler<Subject, SubjectDto>));
            services.AddTransient(typeof(IRequestHandler<DeleteRequest<Subject>, Unit>), typeof(DeleteRequestHandler<Subject>));
            services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<Subject, KnowledgeArea>, Subject>), typeof(AddRelatedEntitiesHandler<Subject, KnowledgeArea>));
            services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<Subject, KnowledgeArea>, Subject>), typeof(RemoveRelatedEntitiesHandler<Subject, KnowledgeArea>));

            // Person
            services.AddTransient(typeof(IRequestHandler<GetAllRequest<Person>, IQueryable<Person>>), typeof(GetAllRequestHandler<Person>));
            services.AddTransient(typeof(IRequestHandler<GetByIdRequest<Person>, IQueryable<Person>>), typeof(GetByIdRequestHandler<Person>));
            services.AddTransient(typeof(IRequestHandler<PostRequest<Person, PersonModel>, Person>), typeof(PostRequestHandler<Person, PersonModel>));
            services.AddTransient(typeof(IRequestHandler<PutRequest<Person, PersonDto>, Person>), typeof(PutRequestHandler<Person, PersonDto>));
            services.AddTransient(typeof(IRequestHandler<DeleteRequest<Person>, Unit>), typeof(DeleteRequestHandler<Person>));

            // Course
            services.AddTransient(typeof(IRequestHandler<GetAllRequest<Course>, IQueryable<Course>>), typeof(GetAllRequestHandler<Course>));
            services.AddTransient(typeof(IRequestHandler<GetByIdRequest<Course>, IQueryable<Course>>), typeof(GetByIdRequestHandler<Course>));
            services.AddTransient(typeof(IRequestHandler<PostRequest<Course, CourseModel>, Course>), typeof(PostRequestHandler<Course, CourseModel>));
            services.AddTransient(typeof(IRequestHandler<PutRequest<Course, CourseDto>, Course>), typeof(PutRequestHandler<Course, CourseDto>));
            services.AddTransient(typeof(IRequestHandler<DeleteRequest<Course>, Unit>), typeof(DeleteRequestHandler<Course>));
            services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<Course, Subject>, Course>), typeof(AddRelatedEntitiesHandler<Course, Subject>));
            services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<Course, Subject>, Course>), typeof(RemoveRelatedEntitiesHandler<Course, Subject>));

            // Teacher
            services.AddTransient(typeof(IRequestHandler<GetAllRequest<Teacher>, IQueryable<Teacher>>), typeof(GetAllRequestHandler<Teacher>));
            services.AddTransient(typeof(IRequestHandler<GetByIdRequest<Teacher>, IQueryable<Teacher>>), typeof(GetByIdRequestHandler<Teacher>));
            services.AddTransient(typeof(IRequestHandler<PostRequest<Teacher, TeacherModel>, Teacher>), typeof(PostRequestHandler<Teacher, TeacherModel>));
            services.AddTransient(typeof(IRequestHandler<PutRequest<Teacher, TeacherDto>, Teacher>), typeof(PutRequestHandler<Teacher, TeacherDto>));
            services.AddTransient(typeof(IRequestHandler<DeleteRequest<Teacher>, Unit>), typeof(DeleteRequestHandler<Teacher>));
        } 
    }
}
