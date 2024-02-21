using System.Numerics;
using backend.api.Database.Entities;
using backend.api.Dtos;
using backend.api.Services;
using backend.tests.Helpers;

namespace backend.tests.Systems.Services;

public class TestItemService
{
    [Fact]
    public async Task GetItems_Returns_Items()
    {
        // Arrange
        var items = new List<ItemEntity>
        {
            new ItemEntity { Id = 1, ItemName = "Item 1", ItemDescription = "Description 1" },
            new ItemEntity { Id = 2, ItemName = "Item 2", ItemDescription = "Description 2" }
        };
        var dbContext = HelperDbContext.CreateDbContext(items);
        var service = new ItemService(dbContext);

        // Act
        var result = await service.GetItems();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);
    }
    
    [Fact]
    public async Task AddItem_Returns_Added_Item()
    {
        // Arrange
        var itemDto = new ItemDto { ItemName = "New Item", ItemDescription = "New Description" };
        var dbContext = HelperDbContext.CreateDbContext(new List<ItemEntity>());
        var service = new ItemService(dbContext);

        // Act
        var result = await service.AddItem(itemDto);

        // Assert
        result.Should().NotBeNull();
        result.ItemName.Should().Be(itemDto.ItemName);
        result.ItemDescription.Should().Be(itemDto.ItemDescription);
    }
    
    [Fact]
    public async Task ItemExists_Returns_Item_IfExists()
    {
        // Arrange
        var itemName = "Existing Item";
        var items = new List<ItemEntity>
        {
            new ItemEntity { Id = 1, ItemName = itemName, ItemDescription = "Description" }
        };
        var dbContext = HelperDbContext.CreateDbContext(items);
        var service = new ItemService(dbContext);

        // Act
        var result = await service.ItemExists(itemName);

        // Assert
        result.Should().NotBeNull();
        result?.ItemName.Should().Be(itemName);
    }
    
    [Fact]
    public async Task ItemExists_Returns_Null_IfNotExists()
    {
        // Arrange
        var itemName = "Nonexistent Item";
        var dbContext = HelperDbContext.CreateDbContext(new List<ItemEntity>());
        var service = new ItemService(dbContext);

        // Act
        var result = await service.ItemExists(itemName);

        // Assert
        result.Should().BeNull();
    }
    [Fact]
    public async Task CalculateFactorials_Returns_CorrectFactorials()
    {
        // Arrange
        var items = new List<ItemEntity>
        {
            new ItemEntity { Id = 1, ItemName = "Item 1", ItemDescription = "Description 1" },
            new ItemEntity { Id = 2, ItemName = "Item 2", ItemDescription = "Description 2" }
        };
        var dbContext = HelperDbContext.CreateDbContext(items);
        var service = new ItemService(dbContext);

        // Act
        var result = await service.CalculateFactorials();

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(2);

        var orderedResults = result.OrderBy(r => r.ItemId).ToList();

        orderedResults[0].ItemId.Should().Be(1);
        orderedResults[1].ItemId.Should().Be(2);
        
        BigInteger.TryParse(orderedResults[0].Factorial, out var firstFactorial).Should().BeTrue();
        BigInteger.TryParse(orderedResults[1].Factorial, out var secondFactorial).Should().BeTrue();
        firstFactorial.Should().Be(1);
        secondFactorial.Should().Be(2);
    }

    
}