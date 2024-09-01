using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Reports.Domain.Model.Commands;
using sweetmanager.API.Reports.Domain.Model.Queries;
using sweetmanager.API.Reports.Domain.Services;
using sweetmanager.API.Reports.Interfaces.REST.Resources;
using sweetmanager.API.Reports.Interfaces.REST.Transform;

using Firebase.Storage;
using Firebase.Auth;



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
    public async Task<IActionResult> CreateReport([FromBody] CreateReportResource resource, IFormFile Image)
    {
        Stream image = Image.OpenReadStream();
        string url = await SubirStorage(image, Image.FileName);
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

    public async Task<string> SubirStorage(Stream archivo, string nombre)
    {
        string email = "losnosequeylosnosecomo@gmail.com"; 
        string password = "codigo123";
        string path = "imagesfirebase-38e3b.appspot.com";
        string apiKey = "AIzaSyC1X7tTKHyeZsZtM8Mv5IUryUs18KHNQQM";

        var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
        var a = await auth.SignInWithEmailAndPasswordAsync(email, password);
        
        var cancellation = new CancellationTokenSource();

        var task = new FirebaseStorage(path, new FirebaseStorageOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                ThrowOnCancel = true
            }).Child("path")
            .Child(nombre)
            .PutAsync(archivo, cancellation.Token); 
        
        var downloadUrl = await task;
        return downloadUrl;
    }
}