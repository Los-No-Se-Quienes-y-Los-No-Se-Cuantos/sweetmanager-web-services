using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.Rooms.Infrastructure.Persistence.EFC.Repositories;

public class BookingRepository(AppDbContext context) : BaseRepository<Booking>(context), IBookingRepository
{
    public async Task<IEnumerable<Booking>> FindBookingsByBedroomIdAsync(int bedroomId)
    {
        return await Context.Set<Booking>().Where(b => b.BedroomId == bedroomId).ToListAsync();
    }
    
    public async Task<IEnumerable<Booking>> FindBookingsByClientIdAsync(int clientId)
    {
        return await Context.Set<Booking>().Where(b => b.ClientId == clientId).ToListAsync();
    }
    
    public async Task<IEnumerable<Booking>> FindBookingsByStartDateAsync(DateTime startdate)
    {
        return await Context.Set<Booking>().Where(b => b.Detail.StartDate == startdate).ToListAsync();
    }
}