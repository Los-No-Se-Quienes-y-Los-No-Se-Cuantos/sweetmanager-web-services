using sweetmanager.API.IAM.Domain.Model.Commands.Role;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.SupervisionAreas;

namespace sweetmanager.API.IAM.Domain.Services.Roles;

public interface IManagerWorkerRoleCommandService
{
    Task<AdministratorWorkerRole?> Handle(CreateManagerWorkerRoleCommand command);
}