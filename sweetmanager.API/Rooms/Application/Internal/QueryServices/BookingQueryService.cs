using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Queries;
using sweetmanager.API.Rooms.Domain.Model.Repositories;
using sweetmanager.API.Rooms.Domain.Model.Services;

namespace sweetmanager.API.Rooms.Application.Internal.QueryServices;

public class BookingQueryService(IBookingRepository bookingRepository) : IBookingQueryService
{
    public async Task<IEnumerable<Booking>> Handle(GetAllBookingsQuery query)
    {
        return await bookingRepository.ListAsync();
    }

    public async Task<Booking?> Handle(GetBookingByIdQuery query)
    {
        return await bookingRepository.FindByIdAsync(query.Id);
    }
}