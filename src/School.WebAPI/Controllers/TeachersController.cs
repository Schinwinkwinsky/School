using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeachersController : ApiControllerBase<
    Teacher,
    TeacherModel,
    TeacherDto,
    GetAllRequest<Teacher>,
    GetByIdRequest<Teacher>,
    PostRequest<Teacher, TeacherModel>,
    PutRequest<Teacher, TeacherDto>,
    DeleteRequest<Teacher>>
{
    public TeachersController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }
}
