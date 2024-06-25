using sweetmanager.API.IAM.Domain.Model.Aggregates;
using sweetmanager.API.IAM.Interfaces.REST.Resources;

namespace sweetmanager.API.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Username);
    }
}