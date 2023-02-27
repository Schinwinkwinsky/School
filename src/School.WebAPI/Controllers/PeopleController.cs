using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.People;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ApiControllerBase<
        Person,
        PersonDto,
        GetAllPeopleRequest,
        GetPersonByIdRequest,
        PostPersonRequest,
        PutPersonRequest,
        DeletePersonRequest>
    {
        public PeopleController(IMapper mapper, IMediator mediator)
            : base(mapper, mediator) { }
    }
}
