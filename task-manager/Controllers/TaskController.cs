using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using task_manager.Domain.DTOs;
using task_manager.Services;

namespace task_manager.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly ILogger<TaskController> _logger;
    private readonly ITaskService _taskService;
    public TaskController(
        IMapper mapper,
        ILogger<TaskController> logger,
        ITaskService taskService
        )
    {
        _mapper = mapper;
        _logger = logger;
        _taskService = taskService;
    }
    
    [HttpPost]
    public async Task<ActionResult<Domain.Entities.Task>> CreateTask(CreateTaskDto createTaskDto)
    {
        var task = _mapper.Map<Domain.Entities.Task>(createTaskDto);

        await _taskService.CreateAsync(task);

        return CreatedAtAction("CreateTask", new { id = task.Id }, task);
    }
    
    [HttpDelete("{id:guid}")]    
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        await _taskService.DeleteAsync(id);
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateCategory(Guid id, UpdateTaskDto updateTaskDto)
    {
        if (id != updateTaskDto.Id)
        {
            return BadRequest("Invalid Task Id");
        }

        var category = await _taskService.GetAsync(id);

        if (category == null)
        {
            return NotFound($"TaskID {id} is not found.");
        }

        _mapper.Map(updateTaskDto, category);

        try
        {
            await _taskService.UpdateAsync(category);
        }
        catch (Exception)
        {
            throw new Exception($"Error occured while updating TaskID {id}.");
        }

        return Ok();
    }
    
    [HttpGet]
    public async Task<IEnumerable<Domain.Entities.Task>> GetTask()
    {
        return await _taskService.GetAllAsync();
    }
    
    
}