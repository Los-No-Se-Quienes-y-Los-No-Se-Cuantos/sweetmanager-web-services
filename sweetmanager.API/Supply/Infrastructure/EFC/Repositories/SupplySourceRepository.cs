using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Domain.Repositories;

namespace sweetmanager.API.Supply.Infrastructure.EFC.Repositories;

public class SupplySourceRepository : BaseRepository<SupplySource>, ISupplySourceRepository
{
    public SupplySourceRepository(AppDbContext context) : base(context) { }
    
    public async Task<SupplySource> GetSupplySourceByIdAsync(int id)
    {
        return await Context.Set<SupplySource>().FirstOrDefaultAsync(c => c.Id == id);
    }
}