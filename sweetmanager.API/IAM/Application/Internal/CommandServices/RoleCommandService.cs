using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Entities;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Repositories;
using sweetmanager.API.IAM.Domain.Services.Roles;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.CommandServices;

public class RoleCommandService(IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IRoleCommandService
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