using sweetmanager.API.IAM.Application.Internal.OutboundContext;
using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Worker;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.Exceptions;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Repositories.Credential;
using sweetmanager.API.IAM.Domain.Repositories.Users;
using sweetmanager.API.IAM.Domain.Services.Roles;
using sweetmanager.API.IAM.Domain.Services.Users.Work;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.CommandServices.Users;

internal class WorkerCommandService(IUnitOfWork unitOfWork, 
    IWorkerRepository workerRepository,
    IHashingService hashingService,
    ITokenService tokenService,
    IWorkerCredentialRepository workerCredentialRepository,
    IWorkerRoleQueryService workerRoleQueryService) : IWorkerCommandService
{
    public async Task<Worker?> Handle(SignUpWorkerCommand command)
    {
        try
        {
            if (await workerRepository.ExistByEmailAsync(command.Email))
                throw new EmailAlreadyExistException(command.Email);

            if (!Enum.TryParse(command.WorkArea, out EWorkerRoles roles))
                throw new WorkerRoleDoesntExistException();

            var workArea = await workerRoleQueryService.Handle(new GetWorkerRoleIdByRoleNameQuery(command.WorkArea));
            
            var user = new Worker(command.UserName, command.Email, new Role(ERoles.ROLE_WORKER), workArea,
                command.ActiveAccount, command.PhoneNumber, command.Name, command.Surname);

            await workerRepository.AddAsync(user);

            await unitOfWork.CompleteAsync();

            return user;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while creating the user: {ex.Message}");
        }
    }

    public async Task<dynamic?> Handle(SignInCommand command)
    {
        try
        {
            var user = await workerRepository.FindByEmailAsync(command.Email);

            if (user is null)
                throw new EmailDoesntExistException();

            var userCredential = await workerCredentialRepository.FindByWorkerIdAsync(user.Id);

            if (!hashingService.VerifyHash(command.Password, userCredential!.Argon2IdUserHash[..24],
                    userCredential!.Argon2IdUserHash[24..]))
                throw new InvalidPasswordException();

            var token = tokenService.GenerateToken(new
            {
                Id = user.Id,
                PasswordHash = userCredential.Argon2IdUserHash,
                Role = user.Role
            });

            return new
            {
                Token = token,
                User = user
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}