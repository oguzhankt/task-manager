using task_manager.Domain.Entities;

namespace task_manager.Domain.DTOs;

public class CreateTaskDto
{
    public string Title { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public Status Status { get; set; }
    
    public DateTime DueDate { get; set; } = DateTime.Now;
}