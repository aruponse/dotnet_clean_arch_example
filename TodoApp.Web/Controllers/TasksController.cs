// TodoApp.Web/Controllers/TasksController.cs
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Commands;
using TodoApp.Application.DTOs;
using TodoApp.Application.Queries;

namespace TodoApp.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TaskDto>>> GetTasks()
    {
        var tasks = await _mediator.Send(new GetTasksQuery());
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskCommand command)
    {
        var task = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
    }
}