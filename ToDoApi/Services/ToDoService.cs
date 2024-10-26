using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Services;

public class ToDoService(ToDoContext context) : IToDoService
{
    public async Task<List<ToDoItem>> GetAllItems()
    {
        return await context.ToDoItems.ToListAsync();
    }
    
    public async Task<List<ToDoItem>> GetOverdueItems()
    {
        return await context.ToDoItems
            .Where(item => item.DueDate.HasValue && item.DueDate < DateTime.Now && !item.IsComplete)
            .ToListAsync();
    }
    
    public async Task<List<ToDoItem>> GetHighPriorityItems()
    {
        return await context.ToDoItems
            .Where(item => item.Priority == PriorityLevel.High && !item.IsComplete)
            .ToListAsync();
    }
    
    public async Task<List<ToDoItem>> GetRecurringItems()
    {
        return await context.ToDoItems
            .Where(item => item.RecurrenceInterval.HasValue)
            .ToListAsync();
    }
    
    public async Task<ToDoItem> GetItemById(long itemId)
    {
        var item = await context.ToDoItems.FindAsync(itemId);
        if (item == null)
        {
            throw new KeyNotFoundException($"Item with ID {itemId} was not found.");
        }
        return item;
    }
    
    public async Task MarkCompleted(long itemId)
    {
        var item = await GetItemById(itemId);
        item.IsComplete = true;
        await context.SaveChangesAsync();
    }

    public async Task<ToDoItem> AddToDoItem(ToDoItem toDoItem)
    {
        context.ToDoItems.Add(toDoItem);
        await context.SaveChangesAsync();
        return toDoItem;
    }
    
    public async Task<bool> DeleteToDoItem(long itemId)
    {
        var item = await context.ToDoItems.FindAsync(itemId);
        if (item == null)
        {
            return false;
        }

        context.ToDoItems.Remove(item);
        await context.SaveChangesAsync();
        return true;
    }
}