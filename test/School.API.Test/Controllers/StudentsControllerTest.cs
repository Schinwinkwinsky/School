using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using School.Application.CQRS.Relations.Students;
using School.Application.DTO;
using School.Application.Profiles;
using School.Domain.Entities;
using School.WebAPI.Controllers;
using Shouldly;
using Xunit;

namespace School.WebAPI.Test.Controllers;

public class StudentsControllerTests
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IMediator> _mediator;

    private readonly StudentsController _controller;

    public StudentsControllerTests()
    {
        // IMapper
        _mapper = new Mock<IMapper>();

        var config = new MapperConfiguration(cfg => cfg.AddProfile(new StudentProfile()));

        _mapper.Setup(m => m.ConfigurationProvider).Returns(config);

        // IMediator
        _mediator = new Mock<IMediator>();

        _controller = new StudentsController(_mapper.Object, _mediator.Object);
    }

    [Fact]
    public async Task RemoveStudentActionResultStatusCodeShouldBe204()
    {
        // arrange
        var student = new Student { Id =  Guid.NewGuid() };

        // act
        var result = await _controller.RemoveAsync(student.Id, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(204);
    }

    [Fact]
    public async Task AddSchoolClassesActionResultStatusCodeShouldBe200()
    {
        // arrange
        var schoolClass = new SchoolClass { Id = Guid.NewGuid() };

        var studentId = Guid.NewGuid();

        var student = new Student { Id = studentId };

        var studentDto = new StudentDto { Id = studentId };

        _mediator.Setup(m => m.Send(It.IsAny<StudentAddSchoolClassesRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(student);

        _mapper.Setup(m => m.Map<StudentDto>(student)).Returns(studentDto);

        // act
        var result = await _controller.AddSchoolClassesAsync(studentId, new[] { schoolClass.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveSchoolClassesActionResultStatusCodeShouldBe200()
    {
        // arrange
        var schoolClass = new SchoolClass { Id = Guid.NewGuid() };

        var studentId = Guid.NewGuid();

        var student = new Student { Id = studentId };

        var studentDto = new StudentDto { Id = studentId };

        _mediator.Setup(m => m.Send(It.IsAny<StudentRemoveSchoolClassesRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(student);

        _mapper.Setup(m => m.Map<StudentDto>(student)).Returns(studentDto);

        // act
        var result = await _controller.RemoveSchoolClassesAsync(studentId, new[] { schoolClass.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }
}
