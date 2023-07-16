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
        // Course
        services.AddTransient<IRequestHandler<GetAllRequest<Course>, IQueryable<Course>>, GetAllRequestHandler<Course>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Course>, IQueryable<Course>>, GetByIdRequestHandler<Course>>();
        services.AddTransient<IRequestHandler<PostRequest<Course, CourseModel>, Course>, PostRequestHandler<Course, CourseModel>>();
        services.AddTransient<IRequestHandler<PutRequest<Course, CourseDto>, Course>, PutRequestHandler<Course, CourseDto>>();
        services.AddTransient<IRequestHandler<DeleteRequest<Course>>, DeleteRequestHandler<Course>>();
        services.AddTransient<IRequestHandler<AddRelatedEntitiesRequest<Course, Subject>, Course>, AddRelatedEntitiesHandler<Course, Subject>>();
        services.AddTransient<IRequestHandler<RemoveRelatedEntitiesRequest<Course, Subject>, Course>, RemoveRelatedEntitiesHandler<Course, Subject>>();

        // KnowledgeArea
        services.AddTransient<IRequestHandler<GetAllRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>, GetAllRequestHandler<KnowledgeArea>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>, GetByIdRequestHandler<KnowledgeArea>>();
        services.AddTransient<IRequestHandler<PostRequest<KnowledgeArea, KnowledgeAreaModel>, KnowledgeArea>, PostRequestHandler<KnowledgeArea, KnowledgeAreaModel>>();
        services.AddTransient<IRequestHandler<PutRequest<KnowledgeArea, KnowledgeAreaDto>, KnowledgeArea>, PutRequestHandler<KnowledgeArea, KnowledgeAreaDto>>();
        services.AddTransient<IRequestHandler<DeleteRequest<KnowledgeArea>>, DeleteRequestHandler<KnowledgeArea>>();
        services.AddTransient<IRequestHandler<AddRelatedEntitiesRequest<KnowledgeArea, Subject>, KnowledgeArea>, AddRelatedEntitiesHandler<KnowledgeArea, Subject>>();
        services.AddTransient<IRequestHandler<RemoveRelatedEntitiesRequest<KnowledgeArea, Subject>, KnowledgeArea>, RemoveRelatedEntitiesHandler<KnowledgeArea, Subject>>();
        services.AddTransient<IRequestHandler<AddRelatedEntitiesRequest<KnowledgeArea, Teacher>, KnowledgeArea>, AddRelatedEntitiesHandler<KnowledgeArea, Teacher>>();
        services.AddTransient<IRequestHandler<RemoveRelatedEntitiesRequest<KnowledgeArea, Teacher>, KnowledgeArea>, RemoveRelatedEntitiesHandler<KnowledgeArea, Teacher>>();

        // Period
        services.AddTransient<IRequestHandler<GetAllRequest<Period>, IQueryable<Period>>, GetAllRequestHandler<Period>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Period>, IQueryable<Period>>, GetByIdRequestHandler<Period>>();
        services.AddTransient<IRequestHandler<PostRequest<Period, PeriodModel>, Period>, PostRequestHandler<Period, PeriodModel>>();
        services.AddTransient<IRequestHandler<PutRequest<Period, PeriodDto>, Period>, PutRequestHandler<Period, PeriodDto>>();
        services.AddTransient<IRequestHandler<DeleteRequest<Period>>, DeleteRequestHandler<Period>>();
        services.AddTransient<IRequestHandler<AddRelatedEntitiesRequest<Period, SchoolClass>, Period>, AddRelatedEntitiesHandler<Period, SchoolClass>>();
        services.AddTransient<IRequestHandler<RemoveRelatedEntitiesRequest<Period, SchoolClass>, Period>, RemoveRelatedEntitiesHandler<Period, SchoolClass>>();

        // Person
        services.AddTransient<IRequestHandler<GetAllRequest<Person>, IQueryable<Person>>, GetAllRequestHandler<Person>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Person>, IQueryable<Person>>, GetByIdRequestHandler<Person>>();
        services.AddTransient<IRequestHandler<PostRequest<Person, PersonModel>, Person>, PostRequestHandler<Person, PersonModel>>();
        services.AddTransient<IRequestHandler<PutRequest<Person, PersonDto>, Person>, PutRequestHandler<Person, PersonDto>>();
        services.AddTransient<IRequestHandler<DeleteRequest<Person>>, DeleteRequestHandler<Person>>();

        // SchoolClass
        services.AddTransient<IRequestHandler<GetAllRequest<SchoolClass>, IQueryable<SchoolClass>>, GetAllRequestHandler<SchoolClass>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<SchoolClass>, IQueryable<SchoolClass>>, GetByIdRequestHandler<SchoolClass>>();
        services.AddTransient<IRequestHandler<PostRequest<SchoolClass, SchoolClassModel>, SchoolClass>, PostRequestHandler<SchoolClass, SchoolClassModel>>();
        services.AddTransient<IRequestHandler<PutRequest<SchoolClass, SchoolClassDto>, SchoolClass>, PutRequestHandler<SchoolClass, SchoolClassDto>>();
        services.AddTransient<IRequestHandler<DeleteRequest<SchoolClass>>, DeleteRequestHandler<SchoolClass>>();
        services.AddTransient<IRequestHandler<AddRelatedEntitiesRequest<SchoolClass, Student>, SchoolClass>, AddRelatedEntitiesHandler<SchoolClass, Student>>();
        services.AddTransient<IRequestHandler<RemoveRelatedEntitiesRequest<SchoolClass, Student>, SchoolClass>, RemoveRelatedEntitiesHandler<SchoolClass, Student>>();

        // Student
        services.AddTransient<IRequestHandler<GetAllRequest<Student>, IQueryable<Student>>, GetAllRequestHandler<Student>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Student>, IQueryable<Student>>, GetByIdRequestHandler<Student>>();
        services.AddTransient<IRequestHandler<PostRequest<Student, StudentModel>, Student>, PostRequestHandler<Student, StudentModel>>();
        services.AddTransient<IRequestHandler<PutRequest<Student, StudentDto>, Student>, PutRequestHandler<Student, StudentDto>>();
        services.AddTransient<IRequestHandler<DeleteRequest<Student>>, DeleteRequestHandler<Student>>();
        services.AddTransient<IRequestHandler<AddRelatedEntitiesRequest<Student, SchoolClass>, Student>, AddRelatedEntitiesHandler<Student, SchoolClass>>();
        services.AddTransient<IRequestHandler<RemoveRelatedEntitiesRequest<Student, SchoolClass>, Student>, RemoveRelatedEntitiesHandler<Student, SchoolClass>>();

        // Subject
        services.AddTransient<IRequestHandler<GetAllRequest<Subject>, IQueryable<Subject>>, GetAllRequestHandler<Subject>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Subject>, IQueryable<Subject>>, GetByIdRequestHandler<Subject>>();
        services.AddTransient<IRequestHandler<PostRequest<Subject, SubjectModel>, Subject>, PostRequestHandler<Subject, SubjectModel>>();
        services.AddTransient<IRequestHandler<PutRequest<Subject, SubjectDto>, Subject>, PutRequestHandler<Subject, SubjectDto>>();
        services.AddTransient<IRequestHandler<DeleteRequest<Subject>>, DeleteRequestHandler<Subject>>();
        services.AddTransient<IRequestHandler<AddRelatedEntitiesRequest<Subject, KnowledgeArea>, Subject>, AddRelatedEntitiesHandler<Subject, KnowledgeArea>>();
        services.AddTransient<IRequestHandler<RemoveRelatedEntitiesRequest<Subject, KnowledgeArea>, Subject>, RemoveRelatedEntitiesHandler<Subject, KnowledgeArea>>();

        // Teacher
        services.AddTransient<IRequestHandler<GetAllRequest<Teacher>, IQueryable<Teacher>>, GetAllRequestHandler<Teacher>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Teacher>, IQueryable<Teacher>>, GetByIdRequestHandler<Teacher>>();
        services.AddTransient<IRequestHandler<PostRequest<Teacher, TeacherModel>, Teacher>, PostRequestHandler<Teacher, TeacherModel>>();
        services.AddTransient<IRequestHandler<PutRequest<Teacher, TeacherDto>, Teacher>, PutRequestHandler<Teacher, TeacherDto>>();
        services.AddTransient<IRequestHandler<DeleteRequest<Teacher>>, DeleteRequestHandler<Teacher>>();
        services.AddTransient<IRequestHandler<AddRelatedEntitiesRequest<Teacher, KnowledgeArea>, Teacher>, AddRelatedEntitiesHandler<Teacher, KnowledgeArea>>();
        services.AddTransient<IRequestHandler<RemoveRelatedEntitiesRequest<Teacher, KnowledgeArea>, Teacher>, RemoveRelatedEntitiesHandler<Teacher, KnowledgeArea>>();
        services.AddTransient<IRequestHandler<AddRelatedEntitiesRequest<Teacher, SchoolClass>, Teacher>, AddRelatedEntitiesHandler<Teacher, SchoolClass>>();
        services.AddTransient<IRequestHandler<RemoveRelatedEntitiesRequest<Teacher, SchoolClass>, Teacher>, RemoveRelatedEntitiesHandler<Teacher, SchoolClass>>();
    }
}
