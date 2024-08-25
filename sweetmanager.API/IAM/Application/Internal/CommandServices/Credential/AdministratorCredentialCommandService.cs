using sweetmanager.API.IAM.Application.Internal.OutboundContext;
using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Credential;
using sweetmanager.API.IAM.Domain.Model.Entities.Credential;
using sweetmanager.API.IAM.Domain.Repositories.Credential;
using sweetmanager.API.IAM.Domain.Services.UserCredentials.Administration;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.CommandServices.Credential;

internal class AdministratorCredentialCommandService(IUnitOfWork unitOfWork, IAdministratorCredentialRepository administratorCredentialRepository, IHashingService hashingService) : IAdministratorCredentialCommandService
{
    public async Task<bool> Handle(CreateUserCredentialCommand command)
    {
        try
        {
            var salt = hashingService.CreateSalt();

            var code = hashingService.HashCode(command.Argon2IdUserHash, salt);

            await administratorCredentialRepository.AddAsync(new AdministratorCredential(command.UserId, string.Concat(salt, code)));

            await unitOfWork.CompleteAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}