using Microsoft.AspNetCore.Mvc;

namespace task_manager.Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ILogger<TaskController> _logger;

    public TaskController(ILogger<TaskController> logger)
    {
        _logger = logger;
    }

    [HttpGet("task")]
    public IEnumerable<Data.Models.Task> Get()
    {
        return new List<Data.Models.Task>();
    }
}