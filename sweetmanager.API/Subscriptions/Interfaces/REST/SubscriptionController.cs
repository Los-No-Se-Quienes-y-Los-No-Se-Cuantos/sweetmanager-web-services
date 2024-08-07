using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using sweetmanager.API.Subscriptions.Domain.Model.Query;
using sweetmanager.API.Subscriptions.Domain.Services;
using sweetmanager.API.Subscriptions.Interfaces.REST.Resources;
using sweetmanager.API.Subscriptions.Interfaces.REST.Transforms;

namespace sweetmanager.API.Subscriptions.Interfaces.REST;

[Authorize]
[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SubscriptionController(
    ISubscriptionCommandService subscriptionCommandService,
    ISubscriptionQueryService subscriptionQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateSubscription(CreateSubscriptionCommandResource resource)
    {
        var command = CreateSubscriptionCommandFromResourceAssembler.ToCommandFromResource(resource);
        
        var subscriptionData = await subscriptionCommandService.Handle(command);
        
        if (subscriptionData is null) return BadRequest();

        return Ok(subscriptionData);
    }
    
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAllSubscriptions()
    {
        var subscriptionsDataList = await subscriptionQueryService.Handle(new GetAllSubscriptionQuery());
        var resources = subscriptionsDataList.Select(SubscriptionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}