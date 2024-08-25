using sweetmanager.API.IAM.Domain.Model.Aggregates.Management;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Domain.Repositories.Users;

public interface IAdministratorRepository : IBaseRepository<Administrator>
{
    Task<Administrator?> FindByEmailAsync(string email);

    Task<bool> ExistsByEmailAsync(string email);

    
    Task<int> FindIdByEmailAsync(string email);

}