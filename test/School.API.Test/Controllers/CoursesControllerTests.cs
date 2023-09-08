using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using School.Application.CQRS.Relations.Courses;
using School.Application.DTO;
using School.Application.Profiles;
using School.Domain.Entities;
using School.WebAPI.Controllers;
using Shouldly;
using Xunit;

namespace School.WebAPI.Test.Controllers;

public class CoursesControllerTests
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IMediator> _mediator;

    private readonly CoursesController _controller;

    public CoursesControllerTests()
    {
        // IMapper
        _mapper = new Mock<IMapper>();

        var config = new MapperConfiguration(cfg => cfg.AddProfile(new CourseProfile()));

        _mapper.Setup(m => m.ConfigurationProvider).Returns(config);

        // IMediator
        _mediator = new Mock<IMediator>(); 

        _controller = new CoursesController(_mapper.Object, _mediator.Object);
    }

    [Fact]
    public async Task RemoveCourseActionResultStatusCodeShouldBe204()
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

        var courseId = Guid.NewGuid();

        var course = new Course { Id =  courseId };

        var courseDto = new CourseDto { Id = courseId };

        _mediator.Setup(m => m.Send(It.IsAny<CourseAddSubjectsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(course);

        _mapper.Setup(m => m.Map<CourseDto>(course)).Returns(courseDto);

        // act
        var result = await _controller.AddSubjectsAsync(courseId, new[] { subject.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveSubjectsActionResultStatusCodeShouldBe200()
    {
        // arrange
        var subject = new Subject { Id = Guid.NewGuid() };

        var courseId = Guid.NewGuid();

        var course = new Course { Id = courseId };

        var courseDto = new CourseDto { Id = courseId };

        _mediator.Setup(m => m.Send(It.IsAny<CourseRemoveSubjectsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(course);

        _mapper.Setup(m => m.Map<CourseDto>(course)).Returns(courseDto);

        // act
        var result = await _controller.RemoveSubjectsAsync(courseId, new[] {subject.Id}, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }
}
