using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sweetmanager. API. Inspection. Domain. Model. Queries;
using sweetmanager.API.Inspection.Domain.Services;
using sweetmanager.API.Inspection.Interfaces.REST.Resources;
using sweetmanager.API.Inspection.Interfaces.REST.Transforms;

namespace sweetmanager.API.Inspection.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class TaskController(ITaskCommandService commandService, ITaskQueryService queryService): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] CreateTaskResource resource)
    {
        var task = await commandService.Handle(CreateTaskCommandFromResourceAssembler.ToCommandFromResource(resource));
        return CreatedAtAction(nameof(GetTaskById), new { taskId = task.Id }, task);
    }



    [HttpGet("worker/{workerId:int}")]
    public async Task<IActionResult> GetAllTasksByWorkerId(int workerId)
    {
        
        var tasks = await queryService.Handle(new GetAllTasksByWorkerIdQuery(workerId));
        var taskResources = tasks.Select(TaskResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(taskResources);
    }


    [HttpGet("{taskId:int}")]
    [ProducesResponseType(typeof(TaskResource), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTaskById(int taskId)
    {
        var task = await queryService.Handle(new GetTaskByIdQuery(taskId));
        
        if (task is null) return BadRequest("Task not found");
        
        var taskResource = TaskResourceFromEntityAssembler.ToResourceFromEntity(task);
        
        return Ok(taskResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await queryService.Handle(new GetAllTasksQuery());
        var taskResources = tasks.Select(TaskResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(taskResources);
    }
}

