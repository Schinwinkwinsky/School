using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.OData.Query;
using Moq;
using School.Application.CQRS.Generics;
using School.Application.Profiles;
using School.Domain.Entities;
using School.WebAPI.Controllers;
using School.WebAPI.Helpers;
using Xunit;

namespace School.WebAPI.Test.Controllers;

public class CoursesControllerTests
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IMediator> _mediator;

    private readonly ICollection<Course> _courses; 

    private readonly CoursesController _controller;

    public CoursesControllerTests()
    {
        _courses = new Course[]
        {
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Course1",
                CreatedAt = DateTime.Now,
                CreatedBy = Guid.NewGuid()
            },
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Course2",
                CreatedAt = DateTime.Now,
                CreatedBy = Guid.NewGuid()
            },
            new Course
            {
                Id = Guid.NewGuid(),
                Name = "Course3",
                CreatedAt = DateTime.Now,
                CreatedBy = Guid.NewGuid()
            }
        };

        // IMapper
        _mapper = new Mock<IMapper>();

        var config = new MapperConfiguration(cfg => cfg.AddProfile(new CourseProfile()));

        _mapper.Setup(m => m.ConfigurationProvider).Returns(config);

        // IMediator
        _mediator = new Mock<IMediator>();

        _controller = new CoursesController(_mapper.Object, _mediator.Object);
    }

    [Fact]
    public async Task GetAllCoursesShouldBringAllItems()
    {
        // arrange
        _mediator.Setup(m => m.Send(It.IsAny<GetAllRequest<Course>>(), It.IsAny<CancellationToken>())).ReturnsAsync(_courses.AsQueryable());

        ODataExpandHelper.GetMembersToExpandNames = (ODataQueryOptions options) => Array.Empty<string>();

        // act
        var coursesDto = await _controller.GetAllAsync(It.IsAny<ODataQueryOptions>(), It.IsAny<CancellationToken>());

        // assert
        Assert.True(coursesDto.Count() == 3);
    }
}
