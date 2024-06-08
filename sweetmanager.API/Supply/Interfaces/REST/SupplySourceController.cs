using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Supply.Domain.Model.Queries;
using sweetmanager.API.Supply.Domain.Services;
using sweetmanager.API.Supply.Interfaces.REST.Resources;
using sweetmanager.API.Supply.Interfaces.REST.Transform;

namespace sweetmanager.API.Supply.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SupplySourceController(
    ISupplySourceCommandService supplySourceCommandService,
    ISupplySourceQueryService supplySourceQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateSupplySource([FromBody] CreateSupplySourceResource resource)
    {
        var createSupplyCommand = CreateSupplySourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var supplySource = await supplySourceCommandService.Handle(createSupplyCommand);
        if (supplySource is null) return BadRequest();
        var supplySourceResource = SupplySourceResourceFromEntityAssembler.ToResourceFromEntity(supplySource);

        return CreatedAtAction(nameof(GetSupplySourceById), new { supplySourceId = supplySourceResource.Id },
            supplySourceResource);
    }
    
    [HttpPost]
    public async Task<IActionResult> GetAllSuppliesSources()
    {
        var getAllSuppliesSourcesQuery = new GetAllSuppliesSourceQuery();
        var supplySources = await supplySourceQueryService.Handle(getAllSuppliesSourcesQuery);
        var supplyResources = supplySources.Select(SupplySourceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(supplyResources);
    }
    
    [HttpGet("{supplySourceId:int}")]
    public async Task<IActionResult> GetSupplySourceById(int supplySourceId)
    {
        var getSupplySourceByIdQuery = new GetSupplySourceByIdQuery(supplySourceId);
        var supplySource = await supplySourceQueryService.Handle(getSupplySourceByIdQuery);
        if (supplySource == null) return NotFound();
        var supplyResource = SupplySourceResourceFromEntityAssembler.ToResourceFromEntity(supplySource);
        return Ok(supplyResource);
    }
}