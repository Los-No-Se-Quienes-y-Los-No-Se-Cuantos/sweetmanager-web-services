using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Domain.Repositories.Credential;

public interface IAdministratorCredentialRepository : IBaseRepository<AdministratorCredential>
{
    Task<AdministratorCredential?> FindByAdministratorIdAsync(int administratorId);
}