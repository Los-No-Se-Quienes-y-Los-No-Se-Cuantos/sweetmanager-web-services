using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Model.Queries;

namespace sweetmanager.API.IAM.Domain.Services.UserCredentials.Administration;

public interface IAdministratorCredentialQueryService
{
    Task<AdministratorCredential?> Handle(GetUserCredentialByUserIdQuery query);
}