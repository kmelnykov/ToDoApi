namespace WebApplication1.Model;

public class ToDoItem
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
    public DateTime? DueDate { get; set; }
    public PriorityLevel Priority { get; set; } = PriorityLevel.Medium;
    public RecurrenceInterval? RecurrenceInterval { get; set; }
}