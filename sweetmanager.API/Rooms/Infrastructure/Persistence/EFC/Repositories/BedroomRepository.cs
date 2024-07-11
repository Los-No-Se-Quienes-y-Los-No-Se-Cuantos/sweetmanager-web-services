using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.ValueObjects;
using sweetmanager.API.Rooms.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.Rooms.Infrastructure.Persistence.EFC.Repositories;

public class BedroomRepository(AppDbContext context) : BaseRepository<Bedroom>(context), IBedroomRepository
{
    public async Task<IEnumerable<Bedroom>> FindBedroomByStateAsync(string state)
    {
        // Convert the string to an enum
        if (!Enum.TryParse(state, out EBedroomStatus status))
        {
            throw new ArgumentException("Invalid state value");
        }
        return await Context.Set<Bedroom>().Where(b => b.BedroomStatus == status).ToListAsync();
    }
}