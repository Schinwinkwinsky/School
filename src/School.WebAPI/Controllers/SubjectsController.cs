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
public class SubjectsController : ApiControllerBase<
    Subject,
    SubjectModel,
    SubjectDto,
    GetAllRequest<Subject>,
    GetByIdRequest<Subject>,
    PostRequest<Subject, SubjectModel>,
    PutRequest<Subject, SubjectDto>,
    DeleteRequest<Subject>>
{
    public SubjectsController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }
}
