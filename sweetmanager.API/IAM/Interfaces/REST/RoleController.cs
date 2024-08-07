using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Services.Roles;
using sweetmanager.API.IAM.Interfaces.REST.Transform;

namespace sweetmanager.API.IAM.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class RoleController(IRoleQueryService roleQueryService) : ControllerBase
{
    
    [HttpGet]
    public async Task<IActionResult> GetAllRoles()
    {
        try
        {
            var roles = await roleQueryService.Handle(new GetAllRolesQuery());

            var roleResources = roles.Select(RoleResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(roleResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}