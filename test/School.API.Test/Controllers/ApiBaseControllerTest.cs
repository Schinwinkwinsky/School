using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.OData.Query;
using Moq;
using School.Application.CQRS.Generics;
using School.Application.DTO;
using School.Application.Models;
using School.Domain.Entities;
using School.WebAPI.Controllers;
using School.WebAPI.Helpers;
using Shouldly;
using Xunit;

namespace School.WebAPI.Test.Controllers;

public class ApiBaseControllerTest
{
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IMediator> _mediator;

    private readonly ApiBaseController<
        TestItem, 
        TestItemModel, 
        TestItemDto, 
        GetAllRequest<TestItem>, 
        GetByIdRequest<TestItem>, 
        InsertRequest<TestItem, TestItemModel>, 
        UpdateRequest<TestItem, TestItemDto>, 
        RemoveRequest<TestItem>> _controller;
    public ApiBaseControllerTest()
    {
        // IMapper
        _mapper = new Mock<IMapper>();

        var config = new MapperConfiguration(cfg => cfg.AddProfile(new TestItemProfile()));

        _mapper.Setup(m => m.ConfigurationProvider).Returns(config);

        // IMediator
        _mediator = new Mock<IMediator>();

        _controller = new ApiBaseController<
            TestItem, 
            TestItemModel, 
            TestItemDto,
            GetAllRequest<TestItem>,
            GetByIdRequest<TestItem>,
            InsertRequest<TestItem, TestItemModel>,
            UpdateRequest<TestItem, TestItemDto>,
            RemoveRequest<TestItem>>(_mapper.Object, _mediator.Object);
    }

    [Fact]
    public async Task GetAllShouldReturnAllItems()
    {
        // arrange
        var items = new TestItem[]
        {
            new TestItem { Id = Guid.NewGuid() },
            new TestItem { Id = Guid.NewGuid() },
            new TestItem { Id = Guid.NewGuid() }
        };

        _mediator.Setup(m => m.Send(It.IsAny<GetAllRequest<TestItem>>(), It.IsAny<CancellationToken>())).ReturnsAsync(items.AsQueryable());

        ODataExpandHelper.GetMembersToExpandNames = (options) => Array.Empty<string>();

        // act
        var itemsDto = await _controller.GetAllAsync(It.IsAny<ODataQueryOptions>(), It.IsAny<CancellationToken>());

        // assert
        itemsDto.Count().ShouldBe(3);
    }

    [Fact]
    public async Task GetByIdShouldReturnTheRightItem()
    {
        // arrange
        var itemId = Guid.NewGuid();

        var items = new TestItem[]
        {
            new TestItem{ Id = itemId }
        };

        _mediator.Setup(m => m.Send(It.IsAny<GetByIdRequest<TestItem>>(), It.IsAny<CancellationToken>())).ReturnsAsync(items.AsQueryable());

        ODataExpandHelper.GetMembersToExpandNames = (options) => Array.Empty<string>();

        // act
        var itemsDto = await _controller.GetByIdAsync(It.IsAny<ODataQueryOptions>(), It.IsAny<Guid>(), It.IsAny<bool>(), It.IsAny<CancellationToken>());

        // assert
        itemsDto.Count().ShouldBe(1);
        itemsDto.ElementAt(0).Id.ShouldBe(itemId);
    }

    [Fact]
    public async Task InsertActionResultStatusCodeShouldBe201()
    {
        // arrange
        var itemId = Guid.NewGuid();

        var item = new TestItem { Id = itemId };

        var itemDto = new TestItemDto { Id = itemId };

        _mediator.Setup(m => m.Send(It.IsAny<InsertRequest<TestItem, TestItemModel>>(), It.IsAny<CancellationToken>())).ReturnsAsync(item);

        _mapper.Setup(m => m.Map<TestItemDto>(item)).Returns(itemDto);

        // act
        var result = await _controller.InsertAsync(It.IsAny<TestItemModel>(), It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(201);
    }

    [Fact]
    public async Task UpdateActionResultStatusCodeShouldBe200()
    {
        // arrange
        var itemId = Guid.NewGuid();

        var item = new TestItem { Id = itemId };

        var itemDto = new TestItemDto { Id = itemId };

        _mediator.Setup(m => m.Send(It.IsAny<UpdateRequest<TestItem, TestItemDto>>(), It.IsAny<CancellationToken>())).ReturnsAsync(item);

        _mapper.Setup(m => m.Map<TestItemDto>(item)).Returns(itemDto);

        // act
        var result = await _controller.UpdateAsync(itemDto, itemId, It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(200);
    }

    [Fact]
    public async Task RemoveActionResultStatusCodeShouldBe204()
    {
        // arrange

        // act
        var result = await _controller.RemoveAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>());

        var statusCodeActionResult = (IStatusCodeActionResult)result;

        // assert
        statusCodeActionResult.StatusCode.ShouldBe(204);
    }

    class TestItem : EntityBase { }

    class TestItemModel : IModel<TestItem>
    {
        public TestItem ToEntity()
        {
            throw new NotImplementedException();
        }
    }

    class TestItemDto : IDto<TestItem>
    {
        public Guid Id { get; set; }

        public void CopyToEntity(TestItem item)
        {
            throw new NotImplementedException();
        }
    }

    class TestItemProfile : Profile
    {
        public TestItemProfile()
        {
            CreateMap<TestItem, TestItemDto>();
        }
    }
}
