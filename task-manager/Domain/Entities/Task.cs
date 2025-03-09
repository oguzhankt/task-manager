using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace task_manager.Domain.Entities;

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
    [MaxLength(50)]
    public string Title { get; set; } = string.Empty;
    
    [MaxLength(300)]
    public string Description { get; set; } = string.Empty;
    
    public Status Status { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DueDate { get; set; } = DateTime.Now;
}