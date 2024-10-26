using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;
using WebApplication1.Services;

namespace Tests;

public class ToDoServiceTests
{
    private readonly DbContextOptions<ToDoContext> _options;

    public ToDoServiceTests()
    {
        // Use an in-memory database for testing
        _options = new DbContextOptionsBuilder<ToDoContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
    }
    
    [Fact]
    public async Task GetOverdueItems_ShouldReturnOnlyOverdueItems()
    {
        using (var context = new ToDoContext(_options))
        {
            // Arrange
            context.ToDoItems.AddRange(
                new ToDoItem { Id = 1, Name = "Task 1", DueDate = DateTime.Now.AddDays(-1), IsComplete = false },
                new ToDoItem { Id = 2, Name = "Task 2", DueDate = DateTime.Now.AddDays(2), IsComplete = false },
                new ToDoItem { Id = 3, Name = "Task 3", DueDate = DateTime.Now.AddDays(-2), IsComplete = true }
            );
            await context.SaveChangesAsync();

            var service = new ToDoService(context);

            // Act
            var overdueItems = await service.GetOverdueItems();

            // Assert
            Assert.Single(overdueItems);
            Assert.Equal("Task 1", overdueItems.First().Name);
        }
    }
    
    [Fact]
    public async Task GetHighPriorityItems_ShouldReturnOnlyHighPriorityAndIncompleteItems()
    {
        using (var context = new ToDoContext(_options))
        {
            // Arrange
            context.ToDoItems.AddRange(
                new ToDoItem { Id = 1, Name = "High Priority Task 1", Priority = PriorityLevel.High, IsComplete = false },
                new ToDoItem { Id = 2, Name = "Medium Priority Task", Priority = PriorityLevel.Medium, IsComplete = false },
                new ToDoItem { Id = 3, Name = "High Priority Task 2", Priority = PriorityLevel.High, IsComplete = true }
            );
            await context.SaveChangesAsync();

            var service = new ToDoService(context);

            // Act
            var highPriorityItems = await service.GetHighPriorityItems();

            // Assert
            Assert.Single(highPriorityItems);
            Assert.Equal("High Priority Task 1", highPriorityItems.First().Name);
        }
    }
    
    [Fact]
    public async Task GetRecurringItems_ShouldReturnOnlyRecurringTasks()
    {
        using (var context = new ToDoContext(_options))
        {
            // Arrange
            context.ToDoItems.AddRange(
                new ToDoItem { Id = 1, Name = "Weekly Task", RecurrenceInterval = RecurrenceInterval.Weekly, IsComplete = false },
                new ToDoItem { Id = 2, Name = "Monthly Task", RecurrenceInterval = RecurrenceInterval.Monthly, IsComplete = false },
                new ToDoItem { Id = 3, Name = "One-time Task", IsComplete = false }
            );
            await context.SaveChangesAsync();

            var service = new ToDoService(context);

            // Act
            var recurringItems = await service.GetRecurringItems();

            // Assert
            Assert.Equal(2, recurringItems.Count);
            Assert.Contains(recurringItems, item => item.Name == "Weekly Task");
            Assert.Contains(recurringItems, item => item.Name == "Monthly Task");
        }
    }
    
    [Fact]
    public async Task AddToDoItem_ShouldAddNewItemWithCorrectProperties()
    {
        using (var context = new ToDoContext(_options))
        {
            // Arrange
            var newItem = new ToDoItem { Name = "New Task", Priority = PriorityLevel.Medium, DueDate = DateTime.Now.AddDays(7) };
            var service = new ToDoService(context);

            // Act
            var addedItem = await service.AddToDoItem(newItem);

            // Assert
            Assert.NotNull(addedItem);
            Assert.Equal("New Task", addedItem.Name);
            Assert.False(addedItem.IsComplete);
            Assert.Equal(PriorityLevel.Medium, addedItem.Priority);
            Assert.Equal(newItem.DueDate, addedItem.DueDate);
        }
    }
    
    [Fact]
    public async Task DeleteToDoItem_ShouldReturnTrueWhenItemExists()
    {
        using (var context = new ToDoContext(_options))
        {
            // Arrange
            var item = new ToDoItem { Id = 1, Name = "Task to Delete", IsComplete = false };
            context.ToDoItems.Add(item);
            await context.SaveChangesAsync();

            var service = new ToDoService(context);

            // Act
            var result = await service.DeleteToDoItem(1);

            // Assert
            Assert.True(result);
            Assert.False(await context.ToDoItems.AnyAsync(x => x.Id == 1));
        }
    }

    [Fact]
    public async Task DeleteToDoItem_ShouldReturnFalseWhenItemDoesNotExist()
    {
        using (var context = new ToDoContext(_options))
        {
            // Arrange
            var service = new ToDoService(context);

            // Act
            var result = await service.DeleteToDoItem(999);

            // Assert
            Assert.False(result);
        }
    }
}