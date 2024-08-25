using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Credential;

namespace sweetmanager.API.IAM.Domain.Services.UserCredentials.Work;

public interface IWorkerCredentialCommandService
{
    Task<bool> Handle(CreateUserCredentialCommand command);
}