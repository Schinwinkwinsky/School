using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class PeopleController : ApiControllerBase<
    Person,
    PersonModel,
    PersonDto,
    GetAllRequest<Person>,
    GetByIdRequest<Person>,
    InsertRequest<Person, PersonModel>,
    UpdateRequest<Person, PersonDto>,
    RemoveRequest<Person>>
{
    public PeopleController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }
}
