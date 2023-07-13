using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class PeriodsController : ApiControllerBase<
    Period,
    PeriodModel,
    PeriodDto,
    GetAllRequest<Period>,
    GetByIdRequest<Period>,
    PostRequest<Period, PeriodModel>,
    PutRequest<Period, PeriodDto>,
    DeleteRequest<Period>>
{
    public PeriodsController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }
}
