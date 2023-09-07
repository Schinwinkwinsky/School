using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.OData.Query;
using Moq;
using School.Application.CQRS.Generics;
using School.Application.CQRS.Relations.Courses;
using School.Application.DTO;
using School.Application.Models;
using School.Application.Profiles;
using School.Domain.Entities;
using School.WebAPI.Controllers;
using School.WebAPI.Helpers;
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
    public async Task AddSubjectsActionResultStatusCodeShouldBe200()
    {
        // arrange
        var subject = new Subject
        {
            Id = Guid.NewGuid()
        };

        var courseId = Guid.NewGuid();
        var courseName = "Course1";

        var course = new Course
        {
            Id = courseId,
            Name = courseName,
            CreatedAt = DateTime.Now,
            CreatedBy = Guid.NewGuid()
        };

        var courseDto = new CourseDto
        {
            Id = courseId,
            Name = courseName
        };

        _mediator.Setup(m => m.Send(It.IsAny<CourseAddSubjectsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(course);

        _mapper.Setup(m => m.Map<CourseDto>(course)).Returns(courseDto);

        // act
        var result = await _controller.AddSubjects(courseId, new[] { subject.Id }, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveSubjectsActionResultStatusCodeShouldBe200()
    {
        // arrange
        var subject = new Subject
        {
            Id = Guid.NewGuid()
        };

        var courseId = Guid.NewGuid();
        var courseName = "Course1";

        var course = new Course
        {
            Id = courseId,
            Name = courseName,
            CreatedAt = DateTime.Now,
            CreatedBy = Guid.NewGuid()
        };

        var courseDto = new CourseDto
        {
            Id = courseId,
            Name = courseName
        };

        _mediator.Setup(m => m.Send(It.IsAny<CourseRemoveSubjectsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(course);

        _mapper.Setup(m => m.Map<CourseDto>(course)).Returns(courseDto);

        // act
        var result = await _controller.RemoveSubjects(courseId, new[] {subject.Id}, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }
}
