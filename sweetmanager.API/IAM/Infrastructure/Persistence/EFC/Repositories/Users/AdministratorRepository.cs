using Microsoft.EntityFrameworkCore;
using sweetmanager.API.IAM.Domain.Model.Aggregates.Management;
using sweetmanager.API.IAM.Domain.Repositories.Users;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories.Users;

internal class AdministratorRepository(AppDbContext context) : BaseRepository<Administrator>(context), IAdministratorRepository
{
    public async Task<Administrator?> FindByEmailAsync(string email)
    {
        return await Context.Set<Administrator>().FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<bool> ExistsByEmailAsync(string email)
    {
        Task<bool>queryAsync = new (() => Context.Set<Administrator>().Any(a => a.Email.Equals(email)));
        
        queryAsync.Start();

        var result = await queryAsync;
        
        return result;
    }

    public async Task<int> FindIdByEmailAsync(string email)
    => await Task.Run(() =>
        (
            from wr in Context.Set<Administrator>().ToList()
            where wr.Email.Equals(email)
            select wr.Id
        ).FirstOrDefault());
}