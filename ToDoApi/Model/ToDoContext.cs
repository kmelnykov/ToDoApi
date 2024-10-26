using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Model;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {
        
    }

    public DbSet<ToDoItem> ToDoItems { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<ToDoItem>().HasData(
        new ToDoItem { Id = 1, Name = "Learn C#", IsComplete = false, DueDate = DateTime.Now.AddDays(7), Priority = PriorityLevel.High },
        new ToDoItem { Id = 2, Name = "Build a Web API", IsComplete = false, DueDate = DateTime.Now.AddDays(10), Priority = PriorityLevel.Medium },
        new ToDoItem { Id = 3, Name = "Test the API", IsComplete = false, DueDate = DateTime.Now.AddDays(15), Priority = PriorityLevel.High },
        new ToDoItem { Id = 4, Name = "Deploy to Production", IsComplete = false, DueDate = DateTime.Now.AddDays(20), Priority = PriorityLevel.High },
        new ToDoItem { Id = 5, Name = "Celebrate", IsComplete = true, Priority = PriorityLevel.Low },
        new ToDoItem { Id = 6, Name = "Write Documentation", IsComplete = false, DueDate = DateTime.Now.AddDays(5), Priority = PriorityLevel.Medium },
        new ToDoItem { Id = 7, Name = "Update GitHub Repository", IsComplete = true, Priority = PriorityLevel.Medium },
        new ToDoItem { Id = 8, Name = "Research Unit Testing", IsComplete = false, DueDate = DateTime.Now.AddDays(3), Priority = PriorityLevel.Low, RecurrenceInterval = RecurrenceInterval.Weekly },
        new ToDoItem { Id = 9, Name = "Refactor Code", IsComplete = false, DueDate = DateTime.Now.AddDays(2), Priority = PriorityLevel.Medium },
        new ToDoItem { Id = 10, Name = "Optimize Performance", IsComplete = false, Priority = PriorityLevel.High, RecurrenceInterval = RecurrenceInterval.Monthly },
        new ToDoItem { Id = 11, Name = "Add Logging", IsComplete = true, Priority = PriorityLevel.Low },
        new ToDoItem { Id = 12, Name = "Set Up CI/CD Pipeline", IsComplete = true, Priority = PriorityLevel.High },
        new ToDoItem { Id = 13, Name = "Create Backup Strategy", IsComplete = false, DueDate = DateTime.Now.AddDays(12), Priority = PriorityLevel.Medium },
        new ToDoItem { Id = 14, Name = "Conduct Code Review", IsComplete = false, DueDate = DateTime.Now.AddDays(8), Priority = PriorityLevel.High },
        new ToDoItem { Id = 15, Name = "Plan Next Sprint", IsComplete = true, Priority = PriorityLevel.Medium },
        new ToDoItem { Id = 16, Name = "Fix Bugs", IsComplete = false, Priority = PriorityLevel.High, DueDate = DateTime.Now.AddDays(1) },
        new ToDoItem { Id = 17, Name = "Prepare for Presentation", IsComplete = false, Priority = PriorityLevel.Medium, DueDate = DateTime.Now.AddDays(14) },
        new ToDoItem { Id = 18, Name = "Clean Up Codebase", IsComplete = true, Priority = PriorityLevel.Low },
        new ToDoItem { Id = 19, Name = "Archive Old Projects", IsComplete = true, Priority = PriorityLevel.Low },
        new ToDoItem { Id = 20, Name = "Analyze User Feedback", IsComplete = false, DueDate = DateTime.Now.AddDays(6), Priority = PriorityLevel.Medium }
    );
    }
}