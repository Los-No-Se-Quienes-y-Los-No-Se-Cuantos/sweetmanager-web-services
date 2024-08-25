using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Domain.Repositories.Roles;

public interface IRoleRepository : IBaseRepository<Role>
{
    Task<Role?> FindByNameAsync(ERoles name);
    
    Task<bool> ExistsByNameAsync(ERoles name);
}