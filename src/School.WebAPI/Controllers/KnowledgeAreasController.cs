using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.KnowledgeAreas;
using School.Application.DTO;
using School.Domain.Entities;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeAreasController : ApiControllerBase<
        KnowledgeArea,
        KnowledgeAreaDto,
        GetAllKnowledgeAreasRequest,
        GetKnowledgeAreaByIdRequest,
        PostKnowledgeAreaRequest,
        PutKnowledgeAreaRequest,
        DeleteKnowledgeAreaRequest>
    {
        public KnowledgeAreasController(IMapper mapper, IMediator mediator)
            : base(mapper, mediator) { }
        
    }
}
