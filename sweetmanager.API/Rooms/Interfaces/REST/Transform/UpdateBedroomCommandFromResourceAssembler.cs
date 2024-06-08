using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class UpdateBedroomCommandFromResourceAssembler
{
    public static UpdateBedroomCommand ToCommandFromResource(UpdateBedroomResource resource) {
        return new UpdateBedroomCommand(resource.Id, resource.TypeBedroomId, resource.TotalBed,
            resource.TotalBathroom, resource.TotalTelevision, resource.State);
    }
}