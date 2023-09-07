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
        services.AddTransient<IRequestHandler<InsertRequest<Course, CourseModel>, Course>, InsertRequestHandler<Course, CourseModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Course, CourseDto>, Course>, UpdateRequestHandler<Course, CourseDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Course>>, RemoveRequestHandler<Course>>();

        // KnowledgeArea
        services.AddTransient<IRequestHandler<GetAllRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>, GetAllRequestHandler<KnowledgeArea>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<KnowledgeArea>, IQueryable<KnowledgeArea>>, GetByIdRequestHandler<KnowledgeArea>>();
        services.AddTransient<IRequestHandler<InsertRequest<KnowledgeArea, KnowledgeAreaModel>, KnowledgeArea>, InsertRequestHandler<KnowledgeArea, KnowledgeAreaModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<KnowledgeArea, KnowledgeAreaDto>, KnowledgeArea>, UpdateRequestHandler<KnowledgeArea, KnowledgeAreaDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<KnowledgeArea>>, RemoveRequestHandler<KnowledgeArea>>();

        // Period
        services.AddTransient<IRequestHandler<GetAllRequest<Period>, IQueryable<Period>>, GetAllRequestHandler<Period>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Period>, IQueryable<Period>>, GetByIdRequestHandler<Period>>();
        services.AddTransient<IRequestHandler<InsertRequest<Period, PeriodModel>, Period>, InsertRequestHandler<Period, PeriodModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Period, PeriodDto>, Period>, UpdateRequestHandler<Period, PeriodDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Period>>, RemoveRequestHandler<Period>>();

        // Person
        services.AddTransient<IRequestHandler<GetAllRequest<Person>, IQueryable<Person>>, GetAllRequestHandler<Person>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Person>, IQueryable<Person>>, GetByIdRequestHandler<Person>>();
        services.AddTransient<IRequestHandler<InsertRequest<Person, PersonModel>, Person>, InsertRequestHandler<Person, PersonModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Person, PersonDto>, Person>, UpdateRequestHandler<Person, PersonDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Person>>, RemoveRequestHandler<Person>>();

        // SchoolClass
        services.AddTransient<IRequestHandler<GetAllRequest<SchoolClass>, IQueryable<SchoolClass>>, GetAllRequestHandler<SchoolClass>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<SchoolClass>, IQueryable<SchoolClass>>, GetByIdRequestHandler<SchoolClass>>();
        services.AddTransient<IRequestHandler<InsertRequest<SchoolClass, SchoolClassModel>, SchoolClass>, InsertRequestHandler<SchoolClass, SchoolClassModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<SchoolClass, SchoolClassDto>, SchoolClass>, UpdateRequestHandler<SchoolClass, SchoolClassDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<SchoolClass>>, RemoveRequestHandler<SchoolClass>>();

        // Student
        services.AddTransient<IRequestHandler<GetAllRequest<Student>, IQueryable<Student>>, GetAllRequestHandler<Student>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Student>, IQueryable<Student>>, GetByIdRequestHandler<Student>>();
        services.AddTransient<IRequestHandler<InsertRequest<Student, StudentModel>, Student>, InsertRequestHandler<Student, StudentModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Student, StudentDto>, Student>, UpdateRequestHandler<Student, StudentDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Student>>, RemoveRequestHandler<Student>>();

        // Subject
        services.AddTransient<IRequestHandler<GetAllRequest<Subject>, IQueryable<Subject>>, GetAllRequestHandler<Subject>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Subject>, IQueryable<Subject>>, GetByIdRequestHandler<Subject>>();
        services.AddTransient<IRequestHandler<InsertRequest<Subject, SubjectModel>, Subject>, InsertRequestHandler<Subject, SubjectModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Subject, SubjectDto>, Subject>, UpdateRequestHandler<Subject, SubjectDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Subject>>, RemoveRequestHandler<Subject>>();

        // Teacher
        services.AddTransient<IRequestHandler<GetAllRequest<Teacher>, IQueryable<Teacher>>, GetAllRequestHandler<Teacher>>();
        services.AddTransient<IRequestHandler<GetByIdRequest<Teacher>, IQueryable<Teacher>>, GetByIdRequestHandler<Teacher>>();
        services.AddTransient<IRequestHandler<InsertRequest<Teacher, TeacherModel>, Teacher>, InsertRequestHandler<Teacher, TeacherModel>>();
        services.AddTransient<IRequestHandler<UpdateRequest<Teacher, TeacherDto>, Teacher>, UpdateRequestHandler<Teacher, TeacherDto>>();
        services.AddTransient<IRequestHandler<RemoveRequest<Teacher>>, RemoveRequestHandler<Teacher>>();
    }
}
