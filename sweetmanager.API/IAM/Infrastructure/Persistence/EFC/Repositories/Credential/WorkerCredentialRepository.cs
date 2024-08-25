using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Repositories.Credential;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories.Credential;

internal class WorkerCredentialRepository(AppDbContext context) :BaseRepository<WorkerCredential>(context), IWorkerCredentialRepository
{
    public async Task<WorkerCredential?> FindByWorkerIdAsync(int workerId)
    {
        Task<WorkerCredential?> queryAsync = new(() =>
        (
            from cc in Context.Set<WorkerCredential>().ToList()
            join u in Context.Set<Worker>().ToList() on cc.WorkerId equals u.Id
            where cc.WorkerId == u.Id
            select cc
        ).FirstOrDefault());
        
        queryAsync.Start();

        var result = await queryAsync;

        return result;
    }
}