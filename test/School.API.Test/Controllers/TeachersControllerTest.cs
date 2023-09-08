using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using School.Application.CQRS.Relations.Teachers;
using School.Application.DTO;
using School.Application.Profiles;
using School.Domain.Entities;
using School.WebAPI.Controllers;
using Shouldly;
using Xunit;

namespace School.WebAPI.Test.Controllers;

public class TeachersControllerTests
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IMediator> _mediator;

    private readonly TeachersController _controller;

    public TeachersControllerTests()
    {
        // IMapper
        _mapper = new Mock<IMapper>();

        var config = new MapperConfiguration(cfg => cfg.AddProfile(new TeacherProfile()));

        _mapper.Setup(m => m.ConfigurationProvider).Returns(config);

        // IMediator
        _mediator = new Mock<IMediator>();

        _controller = new TeachersController(_mapper.Object, _mediator.Object);
    }

    [Fact]
    public async Task RemoveTeacherActionResultStatusCodeShouldBe204()
    {
        // arrange
        var teacher = new Teacher { Id = Guid.NewGuid() };

        // act
        var result = await _controller.RemoveAsync(teacher.Id, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(204);
    }

    [Fact]
    public async Task AddKnowledgeAreasActionResultStatusCodeShouldBe200()
    {
        // arrange
        var knowledgeArea = new KnowledgeArea { Id = Guid.NewGuid() };

        var teacherId = Guid.NewGuid();

        var teacher = new Teacher { Id = teacherId };

        var teacherDto = new TeacherDto { Id = teacherId };

        _mediator.Setup(m => m.Send(It.IsAny<TeacherAddKnowledgeAreasRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(teacher);

        _mapper.Setup(m => m.Map<TeacherDto>(teacher)).Returns(teacherDto);

        // act
        var result = await _controller.AddKnowledgeAreasAsync(teacherId, new[] { knowledgeArea.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveKnowledgeAreasActionResultStatusCodeShouldBe200()
    {
        // arrange
        var knowledgeArea = new KnowledgeArea { Id = Guid.NewGuid() };

        var teacherId = Guid.NewGuid();

        var teacher = new Teacher { Id = teacherId };

        var teacherDto = new TeacherDto { Id = teacherId };

        _mediator.Setup(m => m.Send(It.IsAny<TeacherRemoveKnowledgeAreasRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(teacher);

        _mapper.Setup(m => m.Map<TeacherDto>(teacher)).Returns(teacherDto);

        // act
        var result = await _controller.RemoveKnowledgeAreasAsync(teacherId, new[] { knowledgeArea.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }
}
