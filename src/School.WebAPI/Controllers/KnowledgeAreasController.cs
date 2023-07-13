using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;

namespace School.WebAPI.Controllers;

[Route("api/[controller]")]
public class KnowledgeAreasController : ApiControllerBase<
    KnowledgeArea,
    KnowledgeAreaModel,
    KnowledgeAreaDto,
    GetAllRequest<KnowledgeArea>,
    GetByIdRequest<KnowledgeArea>,
    PostRequest<KnowledgeArea, KnowledgeAreaModel>,
    PutRequest<KnowledgeArea, KnowledgeAreaDto>,
    DeleteRequest<KnowledgeArea>>
{
    public KnowledgeAreasController(IMapper mapper, IMediator mediator)
        : base(mapper, mediator) { }
}
