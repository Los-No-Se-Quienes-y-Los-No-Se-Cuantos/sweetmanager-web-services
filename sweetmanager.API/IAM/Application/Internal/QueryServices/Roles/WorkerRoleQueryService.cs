using sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Repositories.Roles;
using sweetmanager.API.IAM.Domain.Services.Roles;

namespace sweetmanager.API.IAM.Application.Internal.QueryServices.Roles;

public class WorkerRoleQueryService(IWorkerRoleRepository workerRoleRepository): IWorkerRoleQueryService
{
    public async Task<IEnumerable<WorkerRole>> Handle(GetAllRolesQuery query)
        => await workerRoleRepository.ListAsync();

    public async Task<WorkerRole?> Handle(GetWorkerRoleByNameQuery query)
        => await workerRoleRepository.FindByNameAsync(query.Name);

    public async Task<IEnumerable<WorkerRole>> Handle(GetWorkerRolesByValidationQuery query)
        => await workerRoleRepository.ValidateSupervisionAreasByAreas(query.SupervisionAreas);

    public async Task<int> Handle(GetWorkerRoleIdByRoleNameQuery query)
        => await workerRoleRepository.FindByWorkerRoleName(query.Role);
}