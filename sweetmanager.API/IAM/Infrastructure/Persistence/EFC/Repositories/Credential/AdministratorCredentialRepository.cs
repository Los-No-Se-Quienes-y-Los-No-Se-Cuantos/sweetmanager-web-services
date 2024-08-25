using sweetmanager.API.IAM.Domain.Model.Aggregates.Management;
using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Repositories.Credential;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories.Credential;

internal class AdministratorCredentialRepository(AppDbContext context) : BaseRepository<AdministratorCredential>(context), IAdministratorCredentialRepository
{
    public async Task<AdministratorCredential?> FindByAdministratorIdAsync(int administratorId)
    {
        Task<AdministratorCredential?> queryAsync = new(() =>
        (
            from cc in Context.Set<AdministratorCredential>().ToList()
            join u in Context.Set<Administrator>().ToList() on cc.AdminId equals u.Id
            where cc.AdminId == u.Id
            select cc
        ).FirstOrDefault());
        
        queryAsync.Start();
        
        var result = await queryAsync;

        return result;
    }
} 