using sweetmanager.API.Reports.Domain.Model.Commands;
using sweetmanager.API.Reports.Interfaces.REST.Resources;

namespace sweetmanager.API.Reports.Interfaces.REST.Transform;

public class DeleteReportCommandFromResourceAssembler
{
    public static DeleteReportCommand ToCommandFromResource(DeleteReportResource resource)
    {
        return new DeleteReportCommand(resource.Id);
    }
} 