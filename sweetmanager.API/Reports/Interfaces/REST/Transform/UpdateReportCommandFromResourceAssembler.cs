using sweetmanager.API.Reports.Domain.Model.Commands;
using sweetmanager.API.Reports.Interfaces.REST.Resources;

namespace sweetmanager.API.Reports.Interfaces.REST.Transform;

public class UpdateReportCommandFromResourceAssembler
{
    public static UpdateReportCommand ToCommandFromResource(UpdateReportResource resource)
    {
        return new UpdateReportCommand(resource.Id, resource.Title, resource.Content, resource.Image, resource.ReportType);
    }
}