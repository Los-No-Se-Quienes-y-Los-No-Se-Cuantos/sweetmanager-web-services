using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Services.UserCredentials.Administration;
using sweetmanager.API.IAM.Domain.Services.UserCredentials.Work;
using sweetmanager.API.IAM.Domain.Services.Users.Administration;
using sweetmanager.API.IAM.Domain.Services.Users.Work;
using sweetmanager.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication;
using sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication.Administration;
using sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication.Work;
using sweetmanager.API.IAM.Interfaces.REST.Transform.Administration;
using sweetmanager.API.IAM.Interfaces.REST.Transform.Authentication;
using sweetmanager.API.IAM.Interfaces.REST.Transform.Work;

namespace sweetmanager.API.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController(
    IAdministratorCommandService administratorCommandService,
    IAdministratorCredentialCommandService administratorCredentialCommandService,
    IWorkerCommandService workerCommandService,
    IWorkerCredentialCommandService workerCredentialCommandService) : ControllerBase
{
    
    [HttpPost("sign-up-administrator")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpAdministrator([FromBody] SignUpAdministratorResource resource)
    {
        try
        {
            var signUpCommand = SignUpAdministratorCommandFromResourceAssembler.ToCommandFromResource(resource);

            var result = await administratorCommandService.Handle(signUpCommand);
            
            await administratorCredentialCommandService.Handle(new(result, resource.Password));

            return Ok("User created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("sign-up-worker")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUpWorker([FromBody] SignUpWorkerResource resource)
    {
        try
        {
            var signUpCommand = SignUpWorkerCommandFromResourceAssembler.ToCommandFromResource(resource);

            var result = await workerCommandService.Handle(signUpCommand);

            await workerCredentialCommandService.Handle(new(result!.Id, resource.Password));

            return Ok("User created successfully");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        try
        {
            if (!Enum.TryParse(resource.Role, out ERoles roles))
                return BadRequest("Role must exist!");

            var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);
             
            dynamic? authenticatedUser;

            if (roles == ERoles.ROLE_MANAGER)
                authenticatedUser=  await administratorCommandService.Handle(signInCommand);
            else
                authenticatedUser = await workerCommandService.Handle(signInCommand);
            
            var authenticatedUserResource =
                AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser!.User,
                    authenticatedUser.Token);
            
            return Ok(authenticatedUserResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}