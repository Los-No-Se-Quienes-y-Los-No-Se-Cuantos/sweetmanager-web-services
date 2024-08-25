using sweetmanager.API.IAM.Domain.Model.Commands.Role;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;


namespace sweetmanager.API.IAM.Domain.Services.Roles;

using Model.Entities;

public interface IRoleCommandService
{
    Task<Role?> Handle(SeedRolesCommand command);
}