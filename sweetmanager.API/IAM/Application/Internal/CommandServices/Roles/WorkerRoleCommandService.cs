using sweetmanager.API.IAM.Domain.Model.Commands.Role;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Repositories.Roles;
using sweetmanager.API.IAM.Domain.Services.Roles;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.CommandServices.Roles;

internal class WorkerRoleCommandService(IWorkerRoleRepository workerRoleRepository, IUnitOfWork unitOfWork) : IWorkerRoleCommandService
{
    public async Task<WorkerRole?> Handle(SeedSubRolesCommand command)
    {
        foreach (EWorkerRoles role in Enum.GetValues(typeof(EWorkerRoles)))
        {
            if (!await workerRoleRepository.ExistByNameAsync(role))
            {
                await workerRoleRepository.AddAsync(new WorkerRole(role));
            }
        }

        await unitOfWork.CompleteAsync();

        return new WorkerRole(EWorkerRoles.KITCHEN_STAFF);
    }
}