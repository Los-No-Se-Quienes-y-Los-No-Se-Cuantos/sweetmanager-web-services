using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Communication.Domain.Model.Queries;
using sweetmanager.API.Communication.Domain.Services;
using sweetmanager.API.Communication.Interfaces.REST.Resources;
using sweetmanager.API.Communication.Interfaces.REST.Transform;

namespace sweetmanager.API.Communication.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class NotificationController(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationResource resource)
    {
        var createNotificationCommand = CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var notification = await notificationCommandService.Handle(createNotificationCommand);
        
        if (notification == null) BadRequest();
        
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);

        return CreatedAtAction(nameof(GetNotificationById), new { notificationId = notification.Id }, notificationResource);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllNotifications()
    {
        var getAllNotificationsQuery = new GetAllNotificationsQuery();
        
        var notifications = await notificationQueryService.Handle(getAllNotificationsQuery);

        var notificationResources = notifications.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(notificationResources);
    }
    
    
    [HttpGet("{notificationId:int}")]
    public async Task<IActionResult> GetNotificationById(int notificationId)
    {
        var getNotificationByIdQuery = new GetNotificationByIdQuery(notificationId);
        
        var notification = await notificationQueryService.Handle(getNotificationByIdQuery);

        if (notification == null) return NotFound();
        
        var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);

        return Ok(notificationResource);
    }
}