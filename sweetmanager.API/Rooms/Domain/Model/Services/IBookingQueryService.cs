using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Queries;

namespace sweetmanager.API.Rooms.Domain.Model.Services;

public interface IBookingQueryService
{
    Task<Booking> Handle(GetAllBookingsQuery query);
    Task<Booking> Handle(GetBookingByIdQuery query);
}