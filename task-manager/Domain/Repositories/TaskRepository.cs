using Microsoft.EntityFrameworkCore;
using task_manager.Domain.Contexts;
using task_manager.Domain.Entities;
using task_manager.Domain.Repositories.Contracts;
using Task = System.Threading.Tasks.Task;

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

    public async Task<List<Domain.Entities.Task>> GetAllAsync(int limit = 20, int offset = 0, Status? status = null, DateTime? startDate = null, DateTime? endDate = null)
    {
        return await _context.Set<Domain.Entities.Task>()
            .Where(e => status == null || e.Status == status)
            .Where(e => startDate == null || e.DueDate >= startDate)
            .Where(e => endDate == null || e.DueDate <= endDate)
            .Skip(offset)
            .Take(limit)
            .ToListAsync();            
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