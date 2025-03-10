using Microsoft.EntityFrameworkCore;
using task_manager.Domain.Entities;

namespace task_manager.Domain.Contexts;

public class DataContext : DbContext
{
    public DataContext()
    {
        
    }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Domain.Entities.Task> Task { get; set; }
}