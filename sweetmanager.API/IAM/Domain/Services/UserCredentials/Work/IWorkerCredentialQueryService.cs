using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Model.Queries;

namespace sweetmanager.API.IAM.Domain.Services.UserCredentials.Work;

public interface IWorkerCredentialQueryService
{
    Task<WorkerCredential?> Handle(GetUserCredentialByUserIdQuery query);
}