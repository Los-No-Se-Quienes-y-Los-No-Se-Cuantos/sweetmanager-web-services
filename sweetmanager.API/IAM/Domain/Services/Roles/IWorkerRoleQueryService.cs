using sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;
using sweetmanager.API.IAM.Domain.Model.Queries;

namespace sweetmanager.API.IAM.Domain.Services.Roles;

public interface IWorkerRoleQueryService
{
    Task<IEnumerable<WorkerRole>> Handle(GetAllRolesQuery query);

    Task<WorkerRole?> Handle(GetWorkerRoleByNameQuery query);

    Task<IEnumerable<WorkerRole>> Handle(GetWorkerRolesByValidationQuery query);

    Task<int> Handle(GetWorkerRoleIdByRoleNameQuery query);
}