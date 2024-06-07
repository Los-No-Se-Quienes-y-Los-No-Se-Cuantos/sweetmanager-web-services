using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class UpdateBookingCommandFromResourceAssembler
{
    public static UpdateBookingCommand ToCommandFromResource(UpdateBookingResource resource) {
        return new UpdateBookingCommand(resource.Id, resource.ClientId);
    }
}