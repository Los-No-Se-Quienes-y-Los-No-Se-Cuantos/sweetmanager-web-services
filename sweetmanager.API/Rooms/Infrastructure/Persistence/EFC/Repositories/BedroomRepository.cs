using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.Rooms.Infrastructure.Persistence.EFC.Repositories;

public class BedroomRepository(AppDbContext context) : BaseRepository<Bedroom>(context), IBedroomRepository
{
    public async Task<IEnumerable<Bedroom>> FindBedroomByStateAsync(string state)
    {
        return await Context.Set<Bedroom>().Where(b => b.State == state).ToListAsync();
    }
}