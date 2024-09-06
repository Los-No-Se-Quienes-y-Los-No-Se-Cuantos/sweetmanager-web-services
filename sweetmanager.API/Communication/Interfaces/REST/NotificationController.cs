using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Communication.Domain.Model.Queries;
using sweetmanager.API.Communication.Domain.Services;
using sweetmanager.API.Communication.Interfaces.REST.Resources;
using sweetmanager.API.Communication.Interfaces.REST.Transform;
using sweetmanager.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;


namespace sweetmanager.API.Communication.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class NotificationController(INotificationCommandService notificationCommandService, INotificationQueryService notificationQueryService,
                                    IAlertsCommandService alertsCommandService,IAlertsQueryService alertsQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateNotification(CreateNotificationResource resource)
    {
        try
        {
            var createNotificationCommand = CreateNotificationCommandFromResourceAssembler.ToCommandFromResource(resource);
        
            var notification = await notificationCommandService.Handle(createNotificationCommand);
        
            if (notification == null) BadRequest("Could not create notification");
        
            var notificationResource = NotificationResourceFromEntityAssembler.ToResourceFromEntity(notification);

            return Created(HttpContext.Request.Path, notificationResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("alerts")]
    public async Task<IActionResult> CreateAlerts(CreateAlertsResource resource)
    {
        try
        {
            var createAlertsCommand = CreateAlertsCommandFromResourceAssembler.ToCommandFromResource(resource);
            
            var alerts = await alertsCommandService.Handle(createAlertsCommand);
            
            if (alerts is null) BadRequest("Could not create alert");
            
            var alertsResource = AlertsResourceFromEntityAssembler.ToResourceFromEntity(alerts!);
            
            return Created(HttpContext.Request.Path, alertsResource);

        }
        catch (Exception e)
        {
           return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllNotifications()
    {
        try
        {
            var getAllNotificationsQuery = new GetAllNotificationsQuery();

            var notifications = await notificationQueryService.Handle(getAllNotificationsQuery);

            var notificationResources =
                notifications.Select(NotificationResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(notificationResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("alerts")]
    public async Task<IActionResult> GetAllAlerts()
    {
        try
        {
            var getAllAlertsQuery = new GetAllAlertsQuery();
            
            var alerts = await alertsQueryService.Handle(getAllAlertsQuery);
            
            var alertResources = alerts.Select(AlertsResourceFromEntityAssembler.ToResourceFromEntity);
            
            return Ok(alertResources);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}