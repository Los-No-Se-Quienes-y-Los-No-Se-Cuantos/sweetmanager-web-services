using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Repositories.Credential;
using sweetmanager.API.IAM.Domain.Services.UserCredentials.Work;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.QueryServices.Credential;

internal class WorkerCredentialQueryService(IWorkerCredentialRepository workerCredentialRepository) : IWorkerCredentialQueryService
{
    public async Task<WorkerCredential?> Handle(GetUserCredentialByUserIdQuery query)
    {
        return await workerCredentialRepository.FindByWorkerIdAsync(query.UserId);
    }
}