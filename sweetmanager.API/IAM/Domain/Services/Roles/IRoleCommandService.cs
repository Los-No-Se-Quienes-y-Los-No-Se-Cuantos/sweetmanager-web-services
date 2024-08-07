using sweetmanager.API.IAM.Domain.Model.Commands;

namespace sweetmanager.API.IAM.Domain.Services.Roles;

using Model.Entities;

public interface IRoleCommandService
{
    Task<Role?> Handle(SeedRolesCommand command);
}