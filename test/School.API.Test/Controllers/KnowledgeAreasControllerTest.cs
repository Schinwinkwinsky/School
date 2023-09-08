using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using School.Application.CQRS.Relations.KnowledgeAreas;
using School.Application.DTO;
using School.Application.Profiles;
using School.Domain.Entities;
using School.WebAPI.Controllers;
using Shouldly;
using Xunit;

namespace School.WebAPI.Test.Controllers;

public class KnowledgeAreasControllerTest
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IMediator> _mediator;

    private readonly KnowledgeAreasController _controller;

    public KnowledgeAreasControllerTest()
    {
        // IMapper
        _mapper = new Mock<IMapper>();

        var config = new MapperConfiguration(cfg => cfg.AddProfile(new KnowledgeAreaProfile()));

        _mapper.Setup(m => m.ConfigurationProvider).Returns(config);

        // IMediator
        _mediator = new Mock<IMediator>();

        _controller = new KnowledgeAreasController(_mapper.Object, _mediator.Object);
    }

    [Fact]
    public async Task RemoveKnowledgeAreaActionResultStatusCodeShouldBe204()
    {
        // arrange
        var course = new Course { Id = Guid.NewGuid() };

        // act
        var result = await _controller.RemoveAsync(course.Id, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(204);
    }

    [Fact]
    public async Task AddSubjectsActionResultStatusCodeShouldBe200()
    {
        // arrange
        var subject = new Subject { Id = Guid.NewGuid() };

        var knowledgeAreaId = Guid.NewGuid();

        var knowledgeArea = new KnowledgeArea { Id = knowledgeAreaId };

        var knowledgeAreaDto = new KnowledgeAreaDto { Id = knowledgeAreaId };

        _mediator.Setup(m => m.Send(It.IsAny<KnowledgeAreaAddSubjectsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(knowledgeArea);

        _mapper.Setup(m => m.Map<KnowledgeAreaDto>(knowledgeArea)).Returns(knowledgeAreaDto);

        // act
        var result = await _controller.AddSubjectsAsync(knowledgeAreaId, new[] { subject.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task AddTeachersActionResultStatusCodeShouldBe200()
    {
        // arrange
        var teacher = new Teacher { Id = Guid.NewGuid() };

        var knowledgeAreaId = Guid.NewGuid();

        var knowledgeArea = new KnowledgeArea { Id = knowledgeAreaId };

        var knowledgeAreaDto = new KnowledgeAreaDto { Id = knowledgeAreaId };

        _mediator.Setup(m => m.Send(It.IsAny<KnowledgeAreaAddTeachersRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(knowledgeArea);

        _mapper.Setup(m => m.Map<KnowledgeAreaDto>(knowledgeArea)).Returns(knowledgeAreaDto);

        // act
        var result = await _controller.AddTeachersAsync(knowledgeAreaId, new[] { teacher.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveSubjectsActionResultStatusCodeShouldBe200()
    {
        // arrange
        var subject = new Subject { Id = Guid.NewGuid() };

        var knowledgeAreaId = Guid.NewGuid();

        var knowledgeArea = new KnowledgeArea { Id = knowledgeAreaId };

        var knowledgeAreaDto = new KnowledgeAreaDto { Id = knowledgeAreaId };

        _mediator.Setup(m => m.Send(It.IsAny<KnowledgeAreaRemoveSubjectsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(knowledgeArea);

        _mapper.Setup(m => m.Map<KnowledgeAreaDto>(knowledgeArea)).Returns(knowledgeAreaDto);

        // act
        var result = await _controller.RemoveSubjectsAsync(knowledgeAreaId, new[] { subject.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveTeachersActionResultStatusCodeShouldBe200()
    {
        // arrange
        var teacher = new Teacher { Id = Guid.NewGuid() };

        var knowledgeAreaId = Guid.NewGuid();

        var knowledgeArea = new KnowledgeArea { Id = knowledgeAreaId };

        var knowledgeAreaDto = new KnowledgeAreaDto { Id = knowledgeAreaId };

        _mediator.Setup(m => m.Send(It.IsAny<KnowledgeAreaRemoveTeachersRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(knowledgeArea);

        _mapper.Setup(m => m.Map<KnowledgeAreaDto>(knowledgeArea)).Returns(knowledgeAreaDto);

        // act
        var result = await _controller.RemoveTeachersAsync(knowledgeAreaId, new[] { teacher.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }
}
