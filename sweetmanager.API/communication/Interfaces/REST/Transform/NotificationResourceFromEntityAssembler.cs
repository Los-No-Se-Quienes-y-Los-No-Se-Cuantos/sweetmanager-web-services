using sweetmanager.API.communication.Domain.Model.Aggregates;

namespace sweetmanager.API.communication.Interfaces.REST.Transform;

public static class NotificationResourceFromEntityAssembler
{
    public static Notification ToResourceFromEntity(Notification entity)
    {
        return new Notification(entity.Title, entity.Message);
    }
}