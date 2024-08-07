using sweetmanager.API.IAM.Domain.Model.Entities;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Domain.Repositories;

public interface IUserCredentialRepository : IBaseRepository<UserCredential>
{
    Task<UserCredential?> FindByUserIdAsync(int userId);
}