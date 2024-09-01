using sweetmanager.API.Reports.Domain.Model.Commands;
using sweetmanager.API.Reports.Interfaces.REST.Resources;

namespace sweetmanager.API.Reports.Interfaces.REST.Transform;

public class CreateReportCommandFromResourceAssembler
{
    public static CreateReportCommand ToCommandFromResource(CreateReportResource resource)
    {
        return new CreateReportCommand(resource.Title, resource.Content, resource.Image, resource.ReportType);
    }
} 

