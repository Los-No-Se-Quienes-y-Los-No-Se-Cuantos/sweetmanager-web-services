using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Clients.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Clients.Domain.Model.Aggregates;

namespace sweetmanager.API.Clients.Infrastructure.Persistence.EFC.Repositories
{
    public class ClientRepository(AppDbContext context): BaseRepository<Client>(context), IClientRepository
    {
        public async Task<Client?> FindByEmailAsync(string email)
        {
            return await Context.Set<Client>().Where(c => c.Email == email).FirstOrDefaultAsync();
        }
    }
}