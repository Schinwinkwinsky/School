using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class SchoolClassesController : ApiControllerBase<
SchoolClass,
SchoolClassModel,
SchoolClassDto,
GetAllRequest<SchoolClass>,
GetByIdRequest<SchoolClass>,
PostRequest<SchoolClass, SchoolClassModel>,
PutRequest<SchoolClass, SchoolClassDto>,
DeleteRequest<SchoolClass>>
{
    public SchoolClassesController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }
}
