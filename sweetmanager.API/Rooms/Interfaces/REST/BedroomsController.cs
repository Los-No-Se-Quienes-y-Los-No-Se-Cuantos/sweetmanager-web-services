using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Rooms.Domain.Model.Queries;
using sweetmanager.API.Rooms.Domain.Services;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;
using sweetmanager.API.Rooms.Interfaces.REST.Transform;

namespace sweetmanager.API.Rooms.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BedroomsController(IBedroomCommandService bedroomCommandService,
                                IBedroomQueryService bedroomQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBedroom([FromBody] CreateBedroomResource resource)
    {
        var bedroom = await bedroomCommandService.Handle(CreateBedroomCommandFromResourceAssembler.ToCommandFromResource(resource));

        var bedroomResource = BedroomResourceFromEntityAssembler.ToResourceFromEntity(bedroom);

        return Ok(bedroomResource);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateBedroom([FromBody] UpdateBedroomResource resource)
    {
        var bedroom = await bedroomCommandService.Handle(UpdateBedroomCommandFromResourceAssembler.ToCommandFromResource(resource));

        var bedroomResource = BedroomResourceFromEntityAssembler.ToResourceFromEntity(bedroom);

        return Ok(bedroomResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBedrooms()
    {
        var bedrooms = await bedroomQueryService.Handle(new GetAllBedroomsQuery());

        var bedroomResources = bedrooms.Select(BedroomResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(bedroomResources);
    }
    
    [HttpGet("{bedroomId:int}")]
    public async Task<IActionResult> GetBedroomById(int bedroomId)
    {
        var bedroom = await bedroomQueryService.Handle(new GetBedroomByIdQuery(bedroomId));

        if (bedroom is null) return BadRequest();
        
        var bedroomResources = BedroomResourceFromEntityAssembler.ToResourceFromEntity(bedroom);

        return Ok(bedroomResources);
    }

    [HttpGet("{state}")]
    public async Task<IActionResult> GetBedroomByState(string state)
    {
        var bedroom = await bedroomQueryService.Handle(new GetBedroomByStateQuery(state));
        
        var bedroomResources = bedroom.Select(BedroomResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(bedroomResources);
    }
}