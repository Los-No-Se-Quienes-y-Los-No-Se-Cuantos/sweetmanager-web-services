using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Repositories.Credential;
using sweetmanager.API.IAM.Domain.Services.UserCredentials.Administration;

namespace sweetmanager.API.IAM.Application.Internal.QueryServices.Credential;

public class AdministratorCredentialQueryService(IAdministratorCredentialRepository administratorCredentialRepository) : IAdministratorCredentialQueryService
{
    public async Task<AdministratorCredential?> Handle(GetUserCredentialByUserIdQuery query)
    {
        return await administratorCredentialRepository.FindByAdministratorIdAsync(query.UserId);
    }
}