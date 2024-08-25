using sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Domain.Repositories.Roles;

public interface IWorkerRoleRepository : IBaseRepository<WorkerRole>
{
    Task<WorkerRole?> FindByNameAsync(EWorkerRoles name);

    Task<bool> ExistByNameAsync(EWorkerRoles name);
    
    Task<IEnumerable<WorkerRole>> ValidateSupervisionAreasByAreas(ICollection<string> supervisionAreas);

    Task<int> FindByWorkerRoleName(string role);
}