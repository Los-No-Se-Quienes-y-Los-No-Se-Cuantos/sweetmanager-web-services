using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Interfaces.REST.Resources;

namespace sweetmanager.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.UserName, resource.Email, resource.Password);
    }
}