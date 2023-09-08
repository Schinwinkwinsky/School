using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using School.Application.CQRS.Relations.Subjects;
using School.Application.DTO;
using School.Application.Profiles;
using School.Domain.Entities;
using School.WebAPI.Controllers;
using Shouldly;
using Xunit;

namespace School.WebAPI.Test.Controllers;

public class SubjectsControllerTest
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IMediator> _mediator;

    private readonly SubjectsController _controller;

    public SubjectsControllerTest()
    {
        // IMapper
        _mapper = new Mock<IMapper>();

        var config = new MapperConfiguration(cfg => cfg.AddProfile(new SubjectProfile()));

        _mapper.Setup(m => m.ConfigurationProvider).Returns(config);

        // IMediator
        _mediator = new Mock<IMediator>();

        _controller = new SubjectsController(_mapper.Object, _mediator.Object);
    }

    [Fact]
    public async Task RemoveSubjectActionResultStatusCodeShouldBe204()
    {
        // arrange
        var subject = new Subject { Id = Guid.NewGuid() };

        // act
        var result = await _controller.RemoveAsync(subject.Id, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(204);
    }

    [Fact]
    public async Task AddCoursesActionResultStatusCodeShouldBe200()
    {
        // arrange
        var course = new Course { Id = Guid.NewGuid() };

        var subjectId = Guid.NewGuid();

        var subject = new Subject { Id = subjectId };

        var subjectDto = new SubjectDto { Id = subjectId };

        _mediator.Setup(m => m.Send(It.IsAny<SubjectAddCoursesRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(subject);

        _mapper.Setup(m => m.Map<SubjectDto>(subject)).Returns(subjectDto);

        // act
        var result = await _controller.AddCoursesAsync(subjectId, new[] { course.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task AddKnowledgeAreasActionResultStatusCodeShouldBe200()
    {
        // arrange
        var knowledgeArea = new KnowledgeArea { Id = Guid.NewGuid() };

        var subjectId = Guid.NewGuid();

        var subject = new Subject { Id = subjectId };

        var subjectDto = new SubjectDto { Id = subjectId };

        _mediator.Setup(m => m.Send(It.IsAny<SubjectAddKnowledgeAreasRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(subject);

        _mapper.Setup(m => m.Map<SubjectDto>(subject)).Returns(subjectDto);

        // act
        var result = await _controller.AddKnowledgeAreasAsync(subjectId, new[] { knowledgeArea.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveCoursesActionResultStatusCodeShouldBe200()
    {
        // arrange
        var course = new Course { Id = Guid.NewGuid() };

        var subjectId = Guid.NewGuid();

        var subject = new Subject { Id = subjectId };

        var subjectDto = new SubjectDto { Id = subjectId };

        _mediator.Setup(m => m.Send(It.IsAny<SubjectRemoveCoursesRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(subject);

        _mapper.Setup(m => m.Map<SubjectDto>(subject)).Returns(subjectDto);

        // act
        var result = await _controller.RemoveCoursesAsync(subjectId, new[] { course.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveKnowledgeAreasActionResultStatusCodeShouldBe200()
    {
        // arrange
        var knowledgeArea = new KnowledgeArea { Id = Guid.NewGuid() };

        var subjectId = Guid.NewGuid();

        var subject = new Subject { Id = subjectId };

        var subjectDto = new SubjectDto { Id = subjectId };

        _mediator.Setup(m => m.Send(It.IsAny<SubjectRemoveKnowledgeAreasRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(subject);

        _mapper.Setup(m => m.Map<SubjectDto>(subject)).Returns(subjectDto);

        // act
        var result = await _controller.RemoveKnowledgeAreasAsync(subjectId, new[] { knowledgeArea.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }
}
