using sweetmanager.API.IAM.Domain.Model.Aggregates.Management;
using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Manager;

namespace sweetmanager.API.IAM.Domain.Services.Users.Administration;

public interface IAdministratorCommandService
{
    Task<int> Handle(SignUpAdministratorCommand command);

    Task<dynamic?> Handle(SignInCommand command);
}