using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Queries;

namespace sweetmanager.API.Rooms.Domain.Services;

public interface IBookingQueryService
{
    Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query);
    Task<Booking?> Handle(GetBookingByIdQuery query);
    Task<IEnumerable<Booking>> Handle(GetAllBookingsByBedroomIdQuery query);
    Task<IEnumerable<Booking>> Handle(GetAllBookingsByClientIdQuery query);
    Task<IEnumerable<Booking>> Handle(GetAllBookingsByStartDateQuery query);
}