using sweetmanager.API.IAM.Application.Internal.OutboundContext;
using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Entities;
using sweetmanager.API.IAM.Domain.Repositories;
using sweetmanager.API.IAM.Domain.Services.UserCredentials;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.CommandServices;

public class UserCredentialCommandService(IUnitOfWork unitOfWork, IUserCredentialRepository userCredentialRepository,
    IHashingService hashingService) : IUserCredentialCommandService
{
    public async Task<bool> Handle(CreateUserCredentialCommand command)
    {
        try
        {
            var salt = hashingService.CreateSalt();

            var code = hashingService.HashCode(command.Argon2IdUserHash, salt);

            await userCredentialRepository.AddAsync(new UserCredential(command.UserId, string.Concat(salt, code)));

            await unitOfWork.CompleteAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}