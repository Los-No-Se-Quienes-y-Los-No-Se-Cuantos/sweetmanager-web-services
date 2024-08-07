using Microsoft.EntityFrameworkCore;
using sweetmanager.API.IAM.Domain.Model.Entities;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories;

public class RoleRepository(AppDbContext context) : BaseRepository<Role>(context), IRoleRepository
{
    public async Task<Role?> FindByNameAsync(ERoles name) => await Context.Set<Role>().FirstOrDefaultAsync(r => r.Name == name);
    

    public async Task<bool> ExistsByNameAsync(ERoles name) => await Context.Set<Role>().AnyAsync(r => r.Name == name);
    
}