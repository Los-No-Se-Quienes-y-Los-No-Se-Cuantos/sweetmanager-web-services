using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Credential;

namespace sweetmanager.API.IAM.Domain.Services.UserCredentials.Administration;

public interface IAdministratorCredentialCommandService
{
    Task<bool> Handle(CreateUserCredentialCommand command);
    
}