using sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication;
using User = sweetmanager.API.IAM.Domain.Model.Entities.User.User;

namespace sweetmanager.API.IAM.Interfaces.REST.Transform.Authentication;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    }
}