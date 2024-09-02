using sweetmanager.API.Reports.Domain.Model.Commands;
using sweetmanager.API.Reports.Domain.Model.ValueObjects;
using sweetmanager.API.Reports.Interfaces.REST.Resources;

namespace sweetmanager.API.Reports.Interfaces.REST.Transform;

public class CreateReportCommandFromResourceAssembler
{
    public static CreateReportCommand ToCommandFromResource(CreateReportResource resource, string imageUrl)
    {
        if (!Enum.TryParse(resource.ReportType, out EReportType reportType))
        {
            throw new ArgumentException($"Invalid ReportType: {resource.ReportType}");
        }
        
        return new CreateReportCommand(resource.Title, resource.Content, imageUrl, reportType);
    }
}


