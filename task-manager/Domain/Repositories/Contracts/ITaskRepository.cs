using task_manager.Domain.Entities;
using Task = System.Threading.Tasks.Task;

namespace task_manager.Domain.Repositories.Contracts;

public interface ITaskRepository
{
    Task<Domain.Entities.Task?> GetAsync(Guid? taskId);

    Task<List<Domain.Entities.Task>> GetAllAsync(int limit = 20, int offset = 0, Status? status = null, DateTime? startDate = null, DateTime? endDate = null);

    Task<Domain.Entities.Task> CreateAsync(Domain.Entities.Task task);

    Task DeleteAsync(Guid taskId);

    Task UpdateAsync(Domain.Entities.Task task);
}