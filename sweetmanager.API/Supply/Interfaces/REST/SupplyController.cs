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
public class SupplyController(
    ISupplyCommandService supplyCommandService,
    ISupplyQueryService supplyQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateSupplySource([FromBody] CreateSupplyResource resource)
    {
        var createSupplyCommand = CreateSupplyCommandFromResourceAssembler.ToCommandFromResource(resource);
        var supplySource = await supplyCommandService.Handle(createSupplyCommand);
        if (supplySource is null) return BadRequest();
        var supplySourceResource = SupplyResourceFromEntityAssembler.ToResourceFromEntity(supplySource);

        return CreatedAtAction(nameof(GetSupplySourceById), new { supplySourceId = supplySourceResource.Id },
            supplySourceResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllSuppliesSources()
    {
        var getAllSuppliesSourcesQuery = new GetAllSuppliesQuery();
        var supplySources = await supplyQueryService.Handle(getAllSuppliesSourcesQuery);
        var supplyResources = supplySources.Select(SupplyResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(supplyResources);
    }
    
    [HttpGet("{supplySourceId:int}")]
    public async Task<IActionResult> GetSupplySourceById(int supplySourceId)
    {
        var getSupplySourceByIdQuery = new GetSupplyByIdQuery(supplySourceId);
        var supplySource = await supplyQueryService.Handle(getSupplySourceByIdQuery);
        if (supplySource == null) return NotFound();
        var supplyResource = SupplyResourceFromEntityAssembler.ToResourceFromEntity(supplySource);
        return Ok(supplyResource);
    }
}