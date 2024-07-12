using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Clients.Domain.Model.Queries;
using sweetmanager.API.Clients.Domain.Services;
using sweetmanager.API.Clients.Interfaces.REST.Resources;
using sweetmanager.API.Clients.Interfaces.REST.Transform;
using System.Net.Mime;

namespace sweetmanager.API.Clients.Interfaces
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ClientsController(IClientCommandService clientCommandService, IClientQueryService clientQueryService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProfile(CreateClientResource resource)
        {
            var clientData = await clientCommandService.Handle(CreateClientCommandFromResourceAssembler.ToCommandFromResource(resource));

            if (clientData is null) return BadRequest();

            return CreatedAtAction(nameof(GetProfileById), new { profileId = clientData.Id }, clientData);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var clientsDataList = await clientQueryService.Handle(new GetAllClientsQuery());

            return Ok(clientsDataList);
        }

        [HttpGet("{profileId:int}")]
        public async Task<IActionResult> GetProfileById(int profileId)
        {
            var clientData = await clientQueryService.Handle(new GetClientByIdQuery(profileId));

            if (clientData == null) return NotFound();

            return Ok(clientData);
        }
    }
}