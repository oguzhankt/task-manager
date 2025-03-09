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
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // To increase readability in the database "Status" enum is stored as string
        modelBuilder
            .Entity<Domain.Entities.Task>()
            .Property(e => e.Status)
            .HasConversion(
                v => v.ToString(),
                v => (Status)Enum.Parse(typeof(Status), v));
    }
}