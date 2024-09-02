using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class DeleteBookingCommandFromResourceAssembler
{
    public static DeleteBookingCommand ToCommandFromResource(DeleteBookingResource resource) {
        return new DeleteBookingCommand(resource.Id);
    }
}