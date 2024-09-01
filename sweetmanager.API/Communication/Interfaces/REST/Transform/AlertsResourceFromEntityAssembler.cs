using sweetmanager.API.Communication.Domain.Model.Aggregates.Alerts;
using sweetmanager.API.Communication.Interfaces.REST.Resources;

namespace sweetmanager.API.Communication.Interfaces.REST.Transform;

public static class AlertsResourceFromEntityAssembler
{
    public static AlertsResource ToResourceFromEntity(Alerts entity)
    {
        return new AlertsResource(entity.Id,entity.Title,entity.Description);
    }
}
