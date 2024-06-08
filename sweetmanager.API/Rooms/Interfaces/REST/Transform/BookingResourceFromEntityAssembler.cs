using Microsoft.OpenApi.Extensions;
using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class BookingResourceFromEntityAssembler
{
    public static BookingResource ToResourceFromEntity(Booking entity) {

        return new BookingResource(entity.ClientId, entity.BedroomId,
            entity.DetailBooking, entity.BookingStatus.GetDisplayName());
    }
}