using sweetmanager.API.IAM.Domain.Model.Entities.Roles.SupervisionAreas;
using sweetmanager.API.IAM.Domain.Repositories.Roles;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories.Roles;

internal class ManagerWorkerRoleRepository(AppDbContext context) : BaseRepository<AdministratorWorkerRole>(context), IManagerWorkerRoleRepository
{
    
}