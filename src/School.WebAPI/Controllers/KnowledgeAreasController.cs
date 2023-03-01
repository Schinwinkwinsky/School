using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.CQRS.Generics;
using School.Application.CQRS.KnowledgeAreas;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Results;
using School.Domain.Entities;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost("{id}/subjects/add")]
        public async Task<IActionResult> AddSubjectsAsync(int id, AddKnowledgeAreaSubjectsRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var area = await _mediator.Send(request, cancellationToken);

            var areaDto = _mapper.Map<KnowledgeAreaDto>(area);

            var result = Result<KnowledgeAreaDto>.Success(areaDto);

            return Ok(result);
        }

        [HttpPost("{id}/subjects/remove")]
        public async Task<IActionResult> RemoveSubjectsAsync(int id, RemoveKnowledgeAreaSubjectsRequest request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var area = await _mediator.Send(request, cancellationToken);

            var areaDto = _mapper.Map<KnowledgeAreaDto>(area);

            var result = Result<KnowledgeAreaDto>.Success(areaDto);

            return Ok(result);
        }
    }
}
