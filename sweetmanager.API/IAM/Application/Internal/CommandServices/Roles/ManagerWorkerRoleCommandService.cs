using sweetmanager.API.IAM.Domain.Model.Commands.Role;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.SupervisionAreas;
using sweetmanager.API.IAM.Domain.Repositories.Roles;
using sweetmanager.API.IAM.Domain.Services.Roles;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.CommandServices.Roles;

internal class ManagerWorkerRoleCommandService(IUnitOfWork unitOfWork, 
    IManagerWorkerRoleRepository managerWorkerRoleRepository) : IManagerWorkerRoleCommandService
{
    public async Task<AdministratorWorkerRole?> Handle(CreateManagerWorkerRoleCommand command)
    {
        try
        {
            var manager = new AdministratorWorkerRole(command);
            
            await managerWorkerRoleRepository.AddAsync(manager);

            await unitOfWork.CompleteAsync();

            return manager;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}