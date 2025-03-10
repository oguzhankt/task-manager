using AutoMapper;
using Microsoft.EntityFrameworkCore;
using task_manager.Domain.Contexts;
using task_manager.Domain.DTOs;
using task_manager.Domain.Entities;
using task_manager.Domain.Repositories.Contracts;
using Task = System.Threading.Tasks.Task;

namespace task_manager.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<TaskService> _logger;
       
    public TaskService(
        ITaskRepository taskRepository,
        IMapper mapper,
        ILogger<TaskService> logger)
    {         
        _taskRepository = taskRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Domain.Entities.Task> CreateAsync(CreateTaskDto createTaskDto)
    {
        var task = _mapper.Map<Domain.Entities.Task>(createTaskDto);
        
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

    public async Task<List<Domain.Entities.Task>> GetAllAsync(int limit = 20, int offset = 0, int? status = null, DateTime? startDate = null, DateTime? endDate = null)
    {
        return await _taskRepository.GetAllAsync(limit, offset, (Status?)status, startDate, endDate);            
    }

    public async Task<Domain.Entities.Task?> GetAsync(Guid? taskId)
    {
        if(taskId == null)
        {
            return null;
        }
        return await _taskRepository.GetAsync(taskId);            
    }

    public async Task UpdateAsync(UpdateTaskDto updateTaskDto)
    {
        var task = await _taskRepository.GetAsync(updateTaskDto.Id);

        if (task == null)
        {
            _logger.LogWarning($"TaskID {updateTaskDto.Id} is not found.");
        }
        else
        {
            try
            {
                _mapper.Map(updateTaskDto, task);
                await _taskRepository.UpdateAsync(task);
            }
            catch (Exception)
            {
                _logger.LogError($"Error occured while updating TaskID {updateTaskDto.Id}.");
            }
        }
        
    }     
}