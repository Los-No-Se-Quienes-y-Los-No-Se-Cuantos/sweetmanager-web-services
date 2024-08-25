using sweetmanager.API.IAM.Application.Internal.OutboundContext;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Services;
using sweetmanager.API.IAM.Domain.Services.Users.Administration;
using sweetmanager.API.IAM.Domain.Services.Users.Work;
using sweetmanager.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace sweetmanager.API.IAM.Infrastructure.Pipeline.Middleware.Components;

public class RequestAuthorizationMiddleware(RequestDelegate next, ILogger<RequestAuthorizationMiddleware>logger)
{
    public async Task InvokeAsync(HttpContext context, IAdministratorQueryService administratorQueryService, IWorkerQueryService workerQueryService, ITokenService tokenService)
    {
        var endpoint = context.Request.HttpContext.GetEndpoint();
        
        var allowAnonymous =
            context.Request.HttpContext.GetEndpoint()!.Metadata.Any(m =>
                m.GetType() == typeof(AllowAnonymousAttribute));
        
        logger.LogInformation($"Endpoint: {endpoint?.DisplayName}, AllowAnonymous: {allowAnonymous}");
        
        if (allowAnonymous)
        {
            await next(context);

            return;
        }
        
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        var tokenResult = tokenService.ValidateToken(token) ?? throw new Exception("Invalid Token!");

        dynamic? validation = null;
        
        // Only if I have more than 1 Aggregate 
        if (tokenResult.Role == "ROLE_MANAGER")
            validation = await administratorQueryService.Handle(new GetUserByIdQuery(tokenResult.Id));
        
        else if (tokenResult.Role == "ROLE_WORKER")
            validation = await workerQueryService.Handle(new GetUserByIdQuery(tokenResult.Id));
        
        if (validation is null)
            throw new Exception("Invalid credentials!");

        context.Items["Credentials"] = tokenResult;
        
        await next(context);
    }
}