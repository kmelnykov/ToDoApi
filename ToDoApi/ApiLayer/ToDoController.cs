using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace TodoApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private readonly ToDoContext _context;

    public TodoItemsController(ToDoContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ToDoItem>>> GetTodoItems()
    {
        return await _context.ToDoItems.ToListAsync();
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem>> GetTodoItem(long id)
    {
        var todoItem = await _context.ToDoItems.FindAsync(id);

        if (todoItem == null)
        {
            return NotFound();
        }

        return todoItem;
    }
    
    [HttpPost]
    public async Task<ActionResult<ToDoItem>> PostTodoItem(ToDoItem toDoItem)
    {
        _context.ToDoItems.Add(toDoItem);
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodoItem(long id)
    {
        var todoItem = await _context.ToDoItems.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.ToDoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}