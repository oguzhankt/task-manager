using Microsoft.EntityFrameworkCore;
using task_manager.Domain.Contexts;
using task_manager.Repositories.Contracts;

namespace task_manager.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
       
    public TaskService(ITaskRepository taskRepository)
    {         
        this._taskRepository = taskRepository;
    }

    public async Task<Domain.Entities.Task> CreateAsync(Domain.Entities.Task task)
    {
        await _taskRepository.CreateAsync(task);
        return task;
    }

    public async Task DeleteAsync(Guid taskId)
    {
        var task = await _taskRepository.GetAsync(taskId);

        if (task is null)
        {
            throw new Exception($"TaskID {taskId} is not found.");
        }

        await _taskRepository.DeleteAsync(taskId);
    }      

    public async Task<List<Domain.Entities.Task>> GetAllAsync()
    {
        return await _taskRepository.GetAllAsync();            
    }

    public async Task<Domain.Entities.Task?> GetAsync(Guid? taskId)
    {
        if(taskId == null)
        {
            return null;
        }
        return await _taskRepository.GetAsync(taskId);            
    }

    public async Task UpdateAsync(Domain.Entities.Task task)
    {
        await _taskRepository.UpdateAsync(task);
    }     
}