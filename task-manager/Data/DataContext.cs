using Microsoft.EntityFrameworkCore;

namespace task_manager.Data;

public class DataContext : DbContext
{
    public DataContext()
    {
        
    }
    
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Models.Task> Task { get; set; }
}