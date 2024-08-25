using sweetmanager.API.IAM.Domain.Model.Commands.Role;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Repositories.Roles;
using sweetmanager.API.IAM.Domain.Services.Roles;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.CommandServices.Roles;

internal class RoleCommandService(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IRoleCommandService
{
    public async Task<Role?> Handle(SeedRolesCommand command)
    {
        foreach (ERoles role in Enum.GetValues(typeof(ERoles)))
        {
            if(!await roleRepository.ExistsByNameAsync(role))
            {
                await roleRepository.AddAsync(new Role(role));
            }
        }

        await unitOfWork.CompleteAsync();

        return new Role(ERoles.ROLE_WORKER);
    }
}