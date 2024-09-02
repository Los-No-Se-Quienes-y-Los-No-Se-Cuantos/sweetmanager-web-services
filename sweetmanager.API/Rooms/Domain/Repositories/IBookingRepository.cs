using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Rooms.Domain.Repositories;

public interface IBookingRepository : IBaseRepository<Booking>
{
    Task<IEnumerable<Booking>> FindBookingsByClientIdAsync(int clientId);
    Task<IEnumerable<Booking>> FindBookingsByBedroomIdAsync(int bedroomId);
    Task<IEnumerable<Booking>> FindBookingsByStartDateAsync(DateTime startdate);
}