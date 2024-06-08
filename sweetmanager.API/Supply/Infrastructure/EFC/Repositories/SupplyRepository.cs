using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Domain.Repositories;

namespace sweetmanager.API.Supply.Infrastructure.EFC.Repositories;

public class SupplyRepository : BaseRepository<Domain.Model.Aggregates.Supply>, ISupplyRepository
{
    public SupplyRepository(AppDbContext context) : base(context) { }
    
    public async Task<Domain.Model.Aggregates.Supply> GetSupplySourceByIdAsync(int id)
    {
        return await Context.Set<Domain.Model.Aggregates.Supply>().FirstOrDefaultAsync(c => c.Id == id);
    }
}