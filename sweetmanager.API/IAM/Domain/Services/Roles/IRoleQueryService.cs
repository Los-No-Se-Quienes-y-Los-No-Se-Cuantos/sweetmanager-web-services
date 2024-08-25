using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.Queries;

namespace sweetmanager.API.IAM.Domain.Services.Roles;

public interface IRoleQueryService
{
    Task<IEnumerable<Role>> Handle(GetAllRolesQuery query);

    Task<Role?> Handle(GetRoleByNameQuery query);
}