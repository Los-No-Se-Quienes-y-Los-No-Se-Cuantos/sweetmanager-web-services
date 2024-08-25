using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Interfaces.REST.Resources;
using sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication;

namespace sweetmanager.API.IAM.Interfaces.REST.Transform.Authentication;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Email, resource.Password);
    }
}