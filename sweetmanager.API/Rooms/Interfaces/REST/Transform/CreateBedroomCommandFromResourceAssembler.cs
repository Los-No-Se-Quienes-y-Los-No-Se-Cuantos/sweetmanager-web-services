using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class CreateBedroomCommandFromResourceAssembler
{
    public static CreateBedroomCommand ToCommandFromResource(CreateBedroomResource resource) {

        return new CreateBedroomCommand(resource.TypeBedroomId, resource.TotalBeds, resource.TotalBathroom,
            resource.TotalTelevision, resource.State);
    }
}