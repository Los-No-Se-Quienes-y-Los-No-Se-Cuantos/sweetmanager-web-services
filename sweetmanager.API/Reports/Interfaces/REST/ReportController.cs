using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Reports.Domain.Model.Commands;
using sweetmanager.API.Reports.Domain.Model.Queries;
using sweetmanager.API.Reports.Domain.Services;
using sweetmanager.API.Reports.Interfaces.REST.Resources;
using sweetmanager.API.Reports.Interfaces.REST.Transform;

namespace sweetmanager.API.Reports.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ReportController : ControllerBase
{
    IReportCommandService _reportCommandService;
    IReportQueryService _reportQueryService;
    
    public ReportController(IReportCommandService reportCommandService, IReportQueryService reportQueryService)
    {
        _reportCommandService = reportCommandService;
        _reportQueryService = reportQueryService;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateReport([FromBody] CreateReportResource resource)
    {
        var report = await _reportCommandService.Handle(CreateReportCommandFromResourceAssembler.ToCommandFromResource(resource));
        return CreatedAtAction(nameof(GetReportById), new { reportId = report.Id }, report);
    }
    
    
    [HttpGet("{reportId:int}")]
    [ProducesResponseType(typeof(ReportResource), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReportById(int reportId)
    {
        var report = await _reportQueryService.Handle(new GetReportByIdQuery(reportId));
        
        if (report is null) return BadRequest("Report not found");
        
        var reportResource = ReportResourceFromEntityAssembler.ToResourceFromEntity(report);
        
        return Ok(reportResource);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateReport([FromBody] UpdateReportResource resource)
    {
        var report = await _reportCommandService.Handle(UpdateReportCommandFromResourceAssembler.ToCommandFromResource(resource));
        return Ok(ReportResourceFromEntityAssembler.ToResourceFromEntity(report));
    }
    
    [HttpDelete("{reportId:int}")]
    public async Task<IActionResult> DeleteReport(int reportId)
    {
        var report = await _reportCommandService.Handle(new DeleteReportCommand(reportId));
        return Ok(ReportResourceFromEntityAssembler.ToResourceFromEntity(report));
    }
}