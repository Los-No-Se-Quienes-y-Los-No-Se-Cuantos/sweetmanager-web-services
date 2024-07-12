using sweetmanager.API.IAM.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByEmailAsync(string email);
    
    bool ExistsByEmail(string email);
}