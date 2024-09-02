using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Queries;
using sweetmanager.API.Rooms.Domain.Repositories;
using sweetmanager.API.Rooms.Domain.Services;

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
    
    public async Task<IEnumerable<Booking>> Handle(GetAllBookingsByBedroomIdQuery query)
    {
        return await bookingRepository.FindBookingsByBedroomIdAsync(query.BedroomId);
    }
    
    public async Task<IEnumerable<Booking>> Handle(GetAllBookingsByClientIdQuery query)
    {
        return await bookingRepository.FindBookingsByClientIdAsync(query.ClientId);
    }
    
    public async Task<IEnumerable<Booking>> Handle(GetAllBookingsByStartDateQuery query)
    {
        return await bookingRepository.FindBookingsByStartDateAsync(query.StartDate);
    }
}