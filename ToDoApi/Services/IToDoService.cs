using WebApplication1.Model;

namespace WebApplication1.Services;

public interface IToDoService
{
    Task<List<ToDoItem>> GetAllItems();
    Task<List<ToDoItem>> GetOverdueItems();
    Task<List<ToDoItem>> GetHighPriorityItems();
    Task<List<ToDoItem>> GetRecurringItems();
    Task<ToDoItem> GetItemById(long itemId);
    Task MarkCompleted(long itemId);
    Task<ToDoItem> AddToDoItem(ToDoItem toDoItem);
    Task<bool> DeleteToDoItem(long itemId);
}   