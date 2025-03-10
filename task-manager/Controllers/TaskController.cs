using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using task_manager.Domain.DTOs;
using task_manager.Services;

namespace task_manager.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;
    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }
    
    [HttpPost]
    public async Task<ActionResult<Domain.Entities.Task>> CreateTask(CreateTaskDto createTaskDto)
    {
        var task = await _taskService.CreateAsync(createTaskDto);

        return CreatedAtAction("CreateTask", new { id = task.Id }, task);
    }
    
    [HttpDelete("{id:guid}")]    
    public async Task<IActionResult> DeleteTask(Guid id)
    {
        await _taskService.DeleteAsync(id);
        return NoContent();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateTask(Guid id, UpdateTaskDto updateTaskDto)
    {
        if (id != updateTaskDto.Id)
        {
            return BadRequest("Invalid Task Id");
        }
        
        await _taskService.UpdateAsync(updateTaskDto);
        return NoContent();
    }
    
    [HttpGet]
    public async Task<IEnumerable<Domain.Entities.Task>> GetTask(
        int limit = 20, int offset = 0, int? status = null, DateTime? startDate = null, DateTime? endDate = null
        )
    {
        return await _taskService.GetAllAsync(limit, offset, status, startDate, endDate);
    }
    
    
}