using sweetmanager.API.Communication.Domain.Model.Commands;
using sweetmanager.API.Communication.Interfaces.REST.Resources;

namespace sweetmanager.API.Communication.Interfaces.REST.Transform;

public static class CreateAlertsCommandFromResourceAssembler
{
    public static CreateAlertsCommand ToCommandFromResource(CreateAlertsResource resource)
    {
        return new CreateAlertsCommand(resource.Title, resource.Description);
    }
}

