using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Repositories.Roles;
using sweetmanager.API.IAM.Domain.Services.Roles;

namespace sweetmanager.API.IAM.Application.Internal.QueryServices.Roles;

internal class RoleQueryService(IRoleRepository roleRepository) : IRoleQueryService
{
    public async Task<IEnumerable<Role>> Handle(GetAllRolesQuery query)
    {
        return await roleRepository.ListAsync();
    }

    public async Task<Role?> Handle(GetRoleByNameQuery query)
    {
        return await roleRepository.FindByNameAsync(query.Name);
    }
}