using sweetmanager.API.Reports.Domain.Model.Aggregates;
using sweetmanager.API.Reports.Interfaces.REST.Resources;

namespace sweetmanager.API.Reports.Interfaces.REST.Transform;

public class ReportResourceFromEntityAssembler
{
    public static ReportResource ToResourceFromEntity(Report? entity)
    {
        return new ReportResource(entity.Id, entity.Title, entity.Content, entity.Image, entity.ReportType);
    }
}