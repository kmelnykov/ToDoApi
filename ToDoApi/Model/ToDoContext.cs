using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {
        
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }
}