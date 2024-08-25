using sweetmanager.API.IAM.Domain.Model.Commands.Role;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;

namespace sweetmanager.API.IAM.Domain.Services.Roles;

public interface IWorkerRoleCommandService
{
    Task<WorkerRole?> Handle(SeedSubRolesCommand command);
}