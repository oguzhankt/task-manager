using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace task_manager.Data.Models;

public enum Status
{
    Todo,
    InProgress,
    Done
}

[PrimaryKey("Id")]
public class Task
{
    [Required]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public Status Status { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; } = DateTime.Now;
}