using MediatR;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;

namespace School.WebAPI.Extensions;

public static class MediatrExtension
{
    public static void RegisterMediatrHandlers(this IServiceCollection services)
    {
        // KnowledgeArea
        services.AddTransient(typeof(IRequestHandler<GetAllRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>), typeof(GetAllRequestHandler<KnowledgeArea>));
        services.AddTransient(typeof(IRequestHandler<GetByIdRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>), typeof(GetByIdRequestHandler<KnowledgeArea>));
        services.AddTransient(typeof(IRequestHandler<PostRequest<KnowledgeArea, KnowledgeAreaModel>, KnowledgeArea>), typeof(PostRequestHandler<KnowledgeArea, KnowledgeAreaModel>));
        services.AddTransient(typeof(IRequestHandler<PutRequest<KnowledgeArea, KnowledgeAreaDto>, KnowledgeArea>), typeof(PutRequestHandler<KnowledgeArea, KnowledgeAreaDto>));
        services.AddTransient(typeof(IRequestHandler<DeleteRequest<KnowledgeArea>>), typeof(DeleteRequestHandler<KnowledgeArea>));
        services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<KnowledgeArea, Subject>, KnowledgeArea>), typeof(AddRelatedEntitiesHandler<KnowledgeArea, Subject>));
        services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<KnowledgeArea, Subject>, KnowledgeArea>), typeof(RemoveRelatedEntitiesHandler<KnowledgeArea, Subject>));
        services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<KnowledgeArea, Teacher>, KnowledgeArea>), typeof(AddRelatedEntitiesHandler<KnowledgeArea, Teacher>));
        services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<KnowledgeArea, Teacher>, KnowledgeArea>), typeof(RemoveRelatedEntitiesHandler<KnowledgeArea, Teacher>));

        // SchoolClass
        services.AddTransient(typeof(IRequestHandler<GetAllRequest<SchoolClass>, IQueryable<SchoolClass>>), typeof(GetAllRequestHandler<SchoolClass>));
        services.AddTransient(typeof(IRequestHandler<GetByIdRequest<SchoolClass>, IQueryable<SchoolClass>>), typeof(GetByIdRequestHandler<SchoolClass>));
        services.AddTransient(typeof(IRequestHandler<PostRequest<SchoolClass, SchoolClassModel>, SchoolClass>), typeof(PostRequestHandler<SchoolClass, SchoolClassModel>));
        services.AddTransient(typeof(IRequestHandler<PutRequest<SchoolClass, SchoolClassDto>, SchoolClass>), typeof(PutRequestHandler<SchoolClass, SchoolClassDto>));
        services.AddTransient(typeof(IRequestHandler<DeleteRequest<SchoolClass>>), typeof(DeleteRequestHandler<SchoolClass>));
        services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<SchoolClass, Student>, SchoolClass>), typeof(AddRelatedEntitiesHandler<SchoolClass, Student>));
        services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<SchoolClass, Student>, SchoolClass>), typeof(RemoveRelatedEntitiesHandler<SchoolClass, Student>));

        // Student
        services.AddTransient(typeof(IRequestHandler<GetAllRequest<Student>, IQueryable<Student>>), typeof(GetAllRequestHandler<Student>));
        services.AddTransient(typeof(IRequestHandler<GetByIdRequest<Student>, IQueryable<Student>>), typeof(GetByIdRequestHandler<Student>));
        services.AddTransient(typeof(IRequestHandler<PostRequest<Student, StudentModel>, Student>), typeof(PostRequestHandler<Student, StudentModel>));
        services.AddTransient(typeof(IRequestHandler<PutRequest<Student, StudentDto>, Student>), typeof(PutRequestHandler<Student, StudentDto>));
        services.AddTransient(typeof(IRequestHandler<DeleteRequest<Student>>), typeof(DeleteRequestHandler<Student>));
        services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<Student, SchoolClass>, Student>), typeof(AddRelatedEntitiesHandler<Student, SchoolClass>));
        services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<Student, SchoolClass>, Student>), typeof(RemoveRelatedEntitiesHandler<Student, SchoolClass>));

        // Subject
        services.AddTransient(typeof(IRequestHandler<GetAllRequest<Subject>, IQueryable<Subject>>), typeof(GetAllRequestHandler<Subject>));
        services.AddTransient(typeof(IRequestHandler<GetByIdRequest<Subject>, IQueryable<Subject>>), typeof(GetByIdRequestHandler<Subject>));
        services.AddTransient(typeof(IRequestHandler<PostRequest<Subject, SubjectModel>, Subject>), typeof(PostRequestHandler<Subject, SubjectModel>));
        services.AddTransient(typeof(IRequestHandler<PutRequest<Subject, SubjectDto>, Subject>), typeof(PutRequestHandler<Subject, SubjectDto>));
        services.AddTransient(typeof(IRequestHandler<DeleteRequest<Subject>>), typeof(DeleteRequestHandler<Subject>));
        services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<Subject, KnowledgeArea>, Subject>), typeof(AddRelatedEntitiesHandler<Subject, KnowledgeArea>));
        services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<Subject, KnowledgeArea>, Subject>), typeof(RemoveRelatedEntitiesHandler<Subject, KnowledgeArea>));

        // Person
        services.AddTransient(typeof(IRequestHandler<GetAllRequest<Person>, IQueryable<Person>>), typeof(GetAllRequestHandler<Person>));
        services.AddTransient(typeof(IRequestHandler<GetByIdRequest<Person>, IQueryable<Person>>), typeof(GetByIdRequestHandler<Person>));
        services.AddTransient(typeof(IRequestHandler<PostRequest<Person, PersonModel>, Person>), typeof(PostRequestHandler<Person, PersonModel>));
        services.AddTransient(typeof(IRequestHandler<PutRequest<Person, PersonDto>, Person>), typeof(PutRequestHandler<Person, PersonDto>));
        services.AddTransient(typeof(IRequestHandler<DeleteRequest<Person>>), typeof(DeleteRequestHandler<Person>));

        // Course
        services.AddTransient(typeof(IRequestHandler<GetAllRequest<Course>, IQueryable<Course>>), typeof(GetAllRequestHandler<Course>));
        services.AddTransient(typeof(IRequestHandler<GetByIdRequest<Course>, IQueryable<Course>>), typeof(GetByIdRequestHandler<Course>));
        services.AddTransient(typeof(IRequestHandler<PostRequest<Course, CourseModel>, Course>), typeof(PostRequestHandler<Course, CourseModel>));
        services.AddTransient(typeof(IRequestHandler<PutRequest<Course, CourseDto>, Course>), typeof(PutRequestHandler<Course, CourseDto>));
        services.AddTransient(typeof(IRequestHandler<DeleteRequest<Course>>), typeof(DeleteRequestHandler<Course>));
        services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<Course, Subject>, Course>), typeof(AddRelatedEntitiesHandler<Course, Subject>));
        services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<Course, Subject>, Course>), typeof(RemoveRelatedEntitiesHandler<Course, Subject>));

        // Teacher
        services.AddTransient(typeof(IRequestHandler<GetAllRequest<Teacher>, IQueryable<Teacher>>), typeof(GetAllRequestHandler<Teacher>));
        services.AddTransient(typeof(IRequestHandler<GetByIdRequest<Teacher>, IQueryable<Teacher>>), typeof(GetByIdRequestHandler<Teacher>));
        services.AddTransient(typeof(IRequestHandler<PostRequest<Teacher, TeacherModel>, Teacher>), typeof(PostRequestHandler<Teacher, TeacherModel>));
        services.AddTransient(typeof(IRequestHandler<PutRequest<Teacher, TeacherDto>, Teacher>), typeof(PutRequestHandler<Teacher, TeacherDto>));
        services.AddTransient(typeof(IRequestHandler<DeleteRequest<Teacher>>), typeof(DeleteRequestHandler<Teacher>));
        services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<Teacher, KnowledgeArea>, Teacher>), typeof(AddRelatedEntitiesHandler<Teacher, KnowledgeArea>));
        services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<Teacher, KnowledgeArea>, Teacher>), typeof(RemoveRelatedEntitiesHandler<Teacher, KnowledgeArea>));
        services.AddTransient(typeof(IRequestHandler<AddRelatedEntitiesRequest<Teacher, SchoolClass>, Teacher>), typeof(AddRelatedEntitiesHandler<Teacher, SchoolClass>));
        services.AddTransient(typeof(IRequestHandler<RemoveRelatedEntitiesRequest<Teacher, SchoolClass>, Teacher>), typeof(RemoveRelatedEntitiesHandler<Teacher, SchoolClass>));

    }
}
