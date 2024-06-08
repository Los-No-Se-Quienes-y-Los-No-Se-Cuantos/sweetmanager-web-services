using sweetmanager.API.communication.Domain.Model.Commands;
using sweetmanager.API.communication.Interfaces.REST.Resources;

namespace sweetmanager.API.communication.Interfaces.REST.Transform;

public static class CreateNotificationCommandFromResourceAssembler
{
    public static CreateNotificationCommand ToCommandFromResource(CreateNotificationResource resource)
    {
        return new CreateNotificationCommand(resource.Title, resource.Message);
    }
}