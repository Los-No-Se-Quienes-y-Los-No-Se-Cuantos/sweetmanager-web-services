using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class UpdateBedroomStateCommandFromResourceAssembler
{
    public static UpdateBedroomStateCommand ToCommandFromResource(UpdateBedroomStateResource resource)
    {
        return new UpdateBedroomStateCommand(resource.Id, resource.BedroomState);
    }

   
}