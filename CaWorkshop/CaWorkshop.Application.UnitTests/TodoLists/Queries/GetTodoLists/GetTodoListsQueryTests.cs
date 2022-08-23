using AutoMapper;
using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;
using CaWorkshop.Infrastructure.Data;
using FluentAssertions;
namespace CaWorkshop.Application.UnitTests.TodoLists.Queries.GetTodoLists;

public class GetTodoListsQueryTests : IDisposable
{
    private readonly DbContextFactory _contextFactory;
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTodoListsQueryTests()
    {
        _contextFactory = new DbContextFactory();
        _context = _contextFactory.Create();
        _mapper = MapperFactory.Create();
    }

    [Fact]
    public async Task Handle_ReturnsCorrectVmAndListCount()
    {
        // Arrange
        var query = new GetTodoListsQuery();
        var handler = new GetTodoListsQueryHandler(_context, _mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeOfType<TodosVm>();
        result.Lists.Should().HaveCount(1);
        result.Lists[0].Items.Should().HaveCount(4);
    }

    public void Dispose()
    {
        _contextFactory.Dispose();
    }
}
