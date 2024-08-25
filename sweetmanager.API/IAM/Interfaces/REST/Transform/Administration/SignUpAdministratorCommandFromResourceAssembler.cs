using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Manager;
using sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication.Administration;

namespace sweetmanager.API.IAM.Interfaces.REST.Transform.Administration;

public static class SignUpAdministratorCommandFromResourceAssembler
{
    public static SignUpAdministratorCommand ToCommandFromResource(SignUpAdministratorResource resource)
    {
        return new SignUpAdministratorCommand(resource.UserName, resource.Email, resource.Password,
            resource.SupervisionAreas, resource.PhoneNumber,
            resource.Name, resource.Surname, resource.AccountStatus);
    }
}