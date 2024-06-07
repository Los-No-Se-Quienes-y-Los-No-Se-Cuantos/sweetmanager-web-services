using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class CreateBookingCommandFromResourceAssembler
{
    public static CreateBookingCommand ToCommandFromResource(CreateBookingResource resource) {
        return new CreateBookingCommand(resource.ClientId, resource.BedroomId, resource.StartDate,
            resource.FinalDate, resource.TotalPrice, resource.State);
    }
}