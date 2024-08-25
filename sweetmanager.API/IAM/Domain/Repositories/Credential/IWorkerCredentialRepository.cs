using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Domain.Repositories.Credential;

public interface IWorkerCredentialRepository : IBaseRepository<WorkerCredential>
{
    Task<WorkerCredential?> FindByWorkerIdAsync(int workerId);
}