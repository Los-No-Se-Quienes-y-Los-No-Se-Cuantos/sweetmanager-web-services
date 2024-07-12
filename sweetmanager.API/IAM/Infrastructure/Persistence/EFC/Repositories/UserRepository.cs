using Microsoft.EntityFrameworkCore;
using sweetmanager.API.IAM.Domain.Model.Aggregates;
using sweetmanager.API.IAM.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }

    public bool ExistsByEmail(string email)
    {
        return Context.Set<User>().Any(user => user.Email.Equals(email));
    }
}