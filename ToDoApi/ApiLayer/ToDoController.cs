using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;
using WebApplication1.Services;

[ApiController]
[Route("api/[controller]")]
public class ToDoController(IToDoService toDoService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<ToDoItem>>> GetAllItems()
    {
        var items = await toDoService.GetAllItems();
        return Ok(items);
    }
    
    [HttpGet("overdue")]
    public async Task<ActionResult<List<ToDoItem>>> GetOverdueItems()
    {
        var overdueItems = await toDoService.GetOverdueItems();
        return Ok(overdueItems);
    }
    
    [HttpGet("highpriority")]
    public async Task<ActionResult<List<ToDoItem>>> GetHighPriorityItems()
    {
        var highPriorityItems = await toDoService.GetHighPriorityItems();
        return Ok(highPriorityItems);
    }
    
    [HttpGet("recurring")]
    public async Task<ActionResult<List<ToDoItem>>> GetRecurringItems()
    {
        var recurringItems = await toDoService.GetRecurringItems();
        return Ok(recurringItems);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem>> GetToDoItemById(long id)
    {
        var item = await toDoService.GetItemById(id);
        if (item == null)
        {
            return NotFound();
        }

        return Ok(item);
    }
    
    [HttpPatch("{id}/complete")]
    public async Task<ActionResult<ToDoItem>> MarkCompleted(long id)
    { 
        await toDoService.MarkCompleted(id);
        return Ok();
    }
    
    [HttpPost]
    public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem toDoItem)
    {
        var createdItem = await toDoService.AddToDoItem(toDoItem);
        return CreatedAtAction(nameof(GetToDoItemById), new { id = createdItem.Id }, createdItem);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteToDoItem(long id)
    {
        var success = await toDoService.DeleteToDoItem(id);
        if (!success)
        {
            return NotFound();
        }

        return NoContent();
    }
    //[ToDo] remove later
    //test commit
}