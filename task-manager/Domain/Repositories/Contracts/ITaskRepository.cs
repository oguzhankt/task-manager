namespace task_manager.Repositories.Contracts;

public interface ITaskRepository
{
    Task<Domain.Entities.Task?> GetAsync(Guid? taskId);

    Task<List<Domain.Entities.Task>> GetAllAsync();

    Task<Domain.Entities.Task> CreateAsync(Domain.Entities.Task task);

    Task DeleteAsync(Guid taskId);

    Task UpdateAsync(Domain.Entities.Task task);
}