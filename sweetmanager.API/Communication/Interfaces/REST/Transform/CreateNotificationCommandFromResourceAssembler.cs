using sweetmanager.API.Communication.Domain.Model.Commands;
using sweetmanager.API.Communication.Interfaces.REST.Resources;

namespace sweetmanager.API.Communication.Interfaces.REST.Transform;

public static class CreateNotificationCommandFromResourceAssembler
{
    public static CreateNotificationCommand ToCommandFromResource(CreateNotificationResource resource)
    {
        return new CreateNotificationCommand(resource.Title, resource.Message);
    }
}