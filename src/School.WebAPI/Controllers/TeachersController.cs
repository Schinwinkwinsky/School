using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using School.Application.CQRS.Teachers;
using School.Application.DTO;
using School.Application.Results;
using School.WebAPI.Attributes;
using School.WebAPI.Helpers;

namespace School.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public TeachersController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        [EnableQueryPaginatedResult]
        public async Task<IQueryable<TeacherDto>> GetAllAsync(ODataQueryOptions options, CancellationToken cancellationToken)
        {
            var teachers = await _mediator.Send(new GetAllTeachersRequest(), cancellationToken);

            var expand = Expand.GetMembersToExpandNames(options);

            var teachersDto = teachers.ProjectTo<TeacherDto>(_mapper.ConfigurationProvider, null, expand);

            return teachersDto;
        }

        [HttpGet("{id}")]
        [EnableQueryResult]
        public async Task<IQueryable<TeacherDto>> GetByIdAsync(ODataQueryOptions options, int id, CancellationToken cancellationToken)
        {
            var teachers = await _mediator.Send(new GetTeacherByIdRequest { Id = id }, cancellationToken);

            var expand = Expand.GetMembersToExpandNames(options);

            var teachersDto = teachers.ProjectTo<TeacherDto>(_mapper.ConfigurationProvider, null, expand);

            return teachersDto;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(PostTeacherRequest request, CancellationToken cancellationToken)
        {
            var teacher = await _mediator.Send(request, cancellationToken);

            var teacherDto = _mapper.Map<PersonDto>(teacher);

            var result = Result<PersonDto>.Success(teacherDto);

            return CreatedAtAction("GetById", "Teacher", new { id = teacher.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(PutTeacherRequest request, int id, CancellationToken cancellationToken)
        {
            request.Id = id;

            var teacher = await _mediator.Send(request, cancellationToken);

            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            var result = Result<TeacherDto>.Success(teacherDto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteTeacherRequest { Id = id }, cancellationToken);

            return NoContent();
        }
    }
}
