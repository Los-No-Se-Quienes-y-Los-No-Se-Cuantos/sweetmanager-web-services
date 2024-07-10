
using sweetmanager.API.Communication.Domain.Model.Aggregates;
using sweetmanager.API.Communication.Interfaces.REST.Resources;

namespace sweetmanager.API.Communication.Interfaces.REST.Transform;

public static class NotificationResourceFromEntityAssembler
{
    public static NotificationResource ToResourceFromEntity(Notification entity)
    {
        return new NotificationResource(entity.Id,entity.Title, entity.Message);
    }
}