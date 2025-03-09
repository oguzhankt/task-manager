using Microsoft.EntityFrameworkCore;
using task_manager.Domain.Contexts;
using task_manager.Repositories.Contracts;

namespace task_manager.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly DataContext _context;
       
    public TaskRepository(DataContext context)
    {         
        _context = context;
    }

    public async Task<Domain.Entities.Task> CreateAsync(Domain.Entities.Task task)
    {
        await _context.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task DeleteAsync(Guid taskId)
    {
        var task = await GetAsync(taskId);
        if (task != null)
        {
            _context.Set<Domain.Entities.Task>().Remove(task);
            await _context.SaveChangesAsync();
        }
    }      

    public async Task<List<Domain.Entities.Task>> GetAllAsync()
    {
        return await _context.Set<Domain.Entities.Task>().ToListAsync();            
    }

    public async Task<Domain.Entities.Task?> GetAsync(Guid? taskId)
    {
        return await _context.Task.FindAsync(taskId);            
    }

    public async Task UpdateAsync(Domain.Entities.Task task)
    {
        _context.Update(task);
        await _context.SaveChangesAsync();           
    }     
}