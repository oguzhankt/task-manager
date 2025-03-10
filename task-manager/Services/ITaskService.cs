using task_manager.Domain.DTOs;

namespace task_manager.Services;

public interface ITaskService
{
    Task<Domain.Entities.Task?> GetAsync(Guid? taskId);

    Task<List<Domain.Entities.Task>> GetAllAsync(int limit = 20, int offset = 0, int? status = null, DateTime? startDate = null, DateTime? endDate = null);

    Task<Domain.Entities.Task> CreateAsync(CreateTaskDto createTaskDto);

    Task DeleteAsync(Guid taskId);

    Task UpdateAsync(UpdateTaskDto updateTaskDto);
}