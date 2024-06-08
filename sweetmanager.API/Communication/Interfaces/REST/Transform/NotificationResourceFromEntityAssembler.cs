
using sweetmanager.API.Communication.Domain.Model.Aggregates;

namespace sweetmanager.API.Communication.Interfaces.REST.Transform;

public static class NotificationResourceFromEntityAssembler
{
    public static Notification ToResourceFromEntity(Notification entity)
    {
        return new Notification(entity.Title, entity.Message);
    }
}