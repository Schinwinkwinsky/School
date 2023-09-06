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
        services.AddTransient<IRequestHandler<InsertRequest<Course, CourseModel>, Course>, PostRequestHandler<Course, CourseModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Course, CourseDto>, Course>, PutRequestHandler<Course, CourseDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Course>>, DeleteRequestHandler<Course>>();

        // KnowledgeArea
        services.AddTransient<IRequestHandler<GetAllRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>, GetAllRequestHandler<KnowledgeArea>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>, GetByIdRequestHandler<KnowledgeArea>>();
        services.AddTransient<IRequestHandler<InsertRequest<KnowledgeArea, KnowledgeAreaModel>, KnowledgeArea>, PostRequestHandler<KnowledgeArea, KnowledgeAreaModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<KnowledgeArea, KnowledgeAreaDto>, KnowledgeArea>, PutRequestHandler<KnowledgeArea, KnowledgeAreaDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<KnowledgeArea>>, DeleteRequestHandler<KnowledgeArea>>();

        // Period
        services.AddTransient<IRequestHandler<GetAllRequest<Period>, IQueryable<Period>>, GetAllRequestHandler<Period>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Period>, IQueryable<Period>>, GetByIdRequestHandler<Period>>();
        services.AddTransient<IRequestHandler<InsertRequest<Period, PeriodModel>, Period>, PostRequestHandler<Period, PeriodModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Period, PeriodDto>, Period>, PutRequestHandler<Period, PeriodDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Period>>, DeleteRequestHandler<Period>>();

        // Person
        services.AddTransient<IRequestHandler<GetAllRequest<Person>, IQueryable<Person>>, GetAllRequestHandler<Person>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Person>, IQueryable<Person>>, GetByIdRequestHandler<Person>>();
        services.AddTransient<IRequestHandler<InsertRequest<Person, PersonModel>, Person>, PostRequestHandler<Person, PersonModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Person, PersonDto>, Person>, PutRequestHandler<Person, PersonDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Person>>, DeleteRequestHandler<Person>>();

        // SchoolClass
        services.AddTransient<IRequestHandler<GetAllRequest<SchoolClass>, IQueryable<SchoolClass>>, GetAllRequestHandler<SchoolClass>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<SchoolClass>, IQueryable<SchoolClass>>, GetByIdRequestHandler<SchoolClass>>();
        services.AddTransient<IRequestHandler<InsertRequest<SchoolClass, SchoolClassModel>, SchoolClass>, PostRequestHandler<SchoolClass, SchoolClassModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<SchoolClass, SchoolClassDto>, SchoolClass>, PutRequestHandler<SchoolClass, SchoolClassDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<SchoolClass>>, DeleteRequestHandler<SchoolClass>>();

        // Student
        services.AddTransient<IRequestHandler<GetAllRequest<Student>, IQueryable<Student>>, GetAllRequestHandler<Student>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Student>, IQueryable<Student>>, GetByIdRequestHandler<Student>>();
        services.AddTransient<IRequestHandler<InsertRequest<Student, StudentModel>, Student>, PostRequestHandler<Student, StudentModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Student, StudentDto>, Student>, PutRequestHandler<Student, StudentDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Student>>, DeleteRequestHandler<Student>>();

        // Subject
        services.AddTransient<IRequestHandler<GetAllRequest<Subject>, IQueryable<Subject>>, GetAllRequestHandler<Subject>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Subject>, IQueryable<Subject>>, GetByIdRequestHandler<Subject>>();
        services.AddTransient<IRequestHandler<InsertRequest<Subject, SubjectModel>, Subject>, PostRequestHandler<Subject, SubjectModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Subject, SubjectDto>, Subject>, PutRequestHandler<Subject, SubjectDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Subject>>, DeleteRequestHandler<Subject>>();

        // Teacher
        services.AddTransient<IRequestHandler<GetAllRequest<Teacher>, IQueryable<Teacher>>, GetAllRequestHandler<Teacher>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Teacher>, IQueryable<Teacher>>, GetByIdRequestHandler<Teacher>>();
        services.AddTransient<IRequestHandler<InsertRequest<Teacher, TeacherModel>, Teacher>, PostRequestHandler<Teacher, TeacherModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Teacher, TeacherDto>, Teacher>, PutRequestHandler<Teacher, TeacherDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Teacher>>, DeleteRequestHandler<Teacher>>();
    }
}
