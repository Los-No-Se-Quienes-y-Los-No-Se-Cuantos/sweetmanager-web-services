using sweetmanager.API.IAM.Domain.Model.Commands;

namespace sweetmanager.API.IAM.Domain.Services.UserCredentials;

public interface IUserCredentialCommandService
{
    Task<bool> Handle(CreateUserCredentialCommand command);
}