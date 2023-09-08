using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using School.Application.CQRS.Relations.SchoolClasses;
using School.Application.DTO;
using School.Application.Profiles;
using School.Domain.Entities;
using School.WebAPI.Controllers;
using Shouldly;
using Xunit;

namespace School.WebAPI.Test.Controllers;

public class SchoolClassesControllerTests
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IMediator> _mediator;

    private readonly SchoolClassesController _controller;

    public SchoolClassesControllerTests()
    {
        // IMapper
        _mapper = new Mock<IMapper>();

        var config = new MapperConfiguration(cfg => cfg.AddProfile(new SchoolClassProfile()));

        _mapper.Setup(m => m.ConfigurationProvider).Returns(config);

        // IMediator
        _mediator = new Mock<IMediator>();

        _controller = new SchoolClassesController(_mapper.Object, _mediator.Object);
    }

    [Fact]
    public async Task RemoveSchoolClassActionResultStatusCodeShouldBe204()
    {
        // arrange
        var schoolClass = new SchoolClass { Id =  Guid.NewGuid() };

        // act
        var result = await _controller.RemoveAsync(schoolClass.Id, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(204);
    }

    [Fact]
    public async Task AddStudentsActionResultStatusCodeShouldBe200()
    {
        // arrange
        var student = new Student { Id = Guid.NewGuid() };

        var schoolClassId = Guid.NewGuid();

        var schoolClass = new SchoolClass { Id = schoolClassId };

        var schoolClassDto = new SchoolClassDto { Id = schoolClassId };

        _mediator.Setup(m => m.Send(It.IsAny<SchoolClassAddStudentsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(schoolClass);

        _mapper.Setup(m => m.Map<SchoolClassDto>(schoolClass)).Returns(schoolClassDto);

        // act
        var result = await _controller.AddStudentsAsync(schoolClassId, new[] { student.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveStudentsActionResultStatusCodeShouldBe200()
    {
        // arrange
        var student = new Student { Id = Guid.NewGuid() };

        var schoolClassId = Guid.NewGuid();

        var schoolClass = new SchoolClass { Id = schoolClassId };

        var schoolClassDto = new SchoolClassDto { Id = schoolClassId };

        _mediator.Setup(m => m.Send(It.IsAny<SchoolClassRemoveStudentsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(schoolClass);

        _mapper.Setup(m => m.Map<SchoolClassDto>(schoolClass)).Returns(schoolClassDto);

        // act
        var result = await _controller.RemoveStudentsAsync(schoolClassId, new[] { student.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }
}
