using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class StudentsController : ApiControllerBase<
    Student,
    StudentModel,
    StudentDto,
    GetAllRequest<Student>,
    GetByIdRequest<Student>,
    PostRequest<Student, StudentModel>,
    PutRequest<Student, StudentDto>,
    DeleteRequest<Student>>
{
    public StudentsController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }
}
