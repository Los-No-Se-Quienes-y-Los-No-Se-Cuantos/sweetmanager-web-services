using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.IAM.Domain.Services;
using sweetmanager.API.IAM.Domain.Services.UserCredentials;
using sweetmanager.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using sweetmanager.API.IAM.Interfaces.REST.Resources;
using sweetmanager.API.IAM.Interfaces.REST.Transform;

namespace sweetmanager.API.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AuthenticationController(IUserCommandService userCommandService, IUserCredentialCommandService userCredentialCommandService) : ControllerBase
{
    [HttpPost("sign-up")]
    [AllowAnonymous]
    public async Task<IActionResult> SignUp([FromBody] SignUpResource resource)
    {
        try
        {
            var signUpCommand = SignUpCommandFromResourceAssembler.ToCommandFromResource(resource);

            var result = await userCommandService.Handle(signUpCommand);
            
            if(result is null)
                return BadRequest("An error occurred while creating the user");
            
            await userCredentialCommandService.Handle(new(result.Id, resource.Password));
            
            return Ok(new { message = "User created successfully" });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("sign-in")]
    [AllowAnonymous]
    public async Task<IActionResult> SignIn([FromBody] SignInResource resource)
    {
        try
        {
            var signInCommand = SignInCommandFromResourceAssembler.ToCommandFromResource(resource);

            var authenticatedUser = await userCommandService.Handle(signInCommand);

            var authenticatedUserResource =
                AuthenticatedUserResourceFromEntityAssembler.ToResourceFromEntity(authenticatedUser.user,
                    authenticatedUser.token);

            return Ok(authenticatedUserResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }
}