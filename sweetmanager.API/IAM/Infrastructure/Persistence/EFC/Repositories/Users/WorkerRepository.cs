using Microsoft.EntityFrameworkCore;
using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Domain.Repositories.Users;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories.Users;

internal class WorkerRepository(AppDbContext context) : BaseRepository<Worker>(context), IWorkerRepository 
{
    public async Task<Worker?> FindByEmailAsync(string email)
    {
        return await Context.Set<Worker>().FirstOrDefaultAsync(w => w.Email.Equals(email));
    }

    public async Task<bool> ExistByEmailAsync(string email)
    {
        Task<bool>queryAsync = new(() =>Context.Set<Worker>().Any(w => w.Email.Equals(email)));
        
        queryAsync.Start();
        
        var result = await queryAsync;

        return result;
    }
}