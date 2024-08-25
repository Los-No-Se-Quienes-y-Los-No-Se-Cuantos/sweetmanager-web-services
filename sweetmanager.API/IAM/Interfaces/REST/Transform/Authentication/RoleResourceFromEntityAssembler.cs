using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Interfaces.REST.Resources;

namespace sweetmanager.API.IAM.Interfaces.REST.Transform.Authentication;

public class RoleResourceFromEntityAssembler
{
    public static RoleResource ToResourceFromEntity(Role entity)
    {
        return new RoleResource(entity.Id, entity.GetStringName());
    }
}