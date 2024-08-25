using sweetmanager.API.IAM.Application.Internal.OutboundContext;
using sweetmanager.API.IAM.Domain.Model.Aggregates.Management;
using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Manager;
using sweetmanager.API.IAM.Domain.Model.Commands.Role;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.Standard;
using sweetmanager.API.IAM.Domain.Model.Exceptions;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Repositories.Credential;
using sweetmanager.API.IAM.Domain.Repositories.Users;
using sweetmanager.API.IAM.Domain.Services.Roles;
using sweetmanager.API.IAM.Domain.Services.Users.Administration;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.CommandServices.Users;

internal class AdministratorCommandService(IUnitOfWork unitOfWork, 
    IAdministratorRepository administratorRepository, 
    IHashingService hashingService, 
    IAdministratorCredentialRepository administratorCredentialRepository, 
    ITokenService tokenService,
    IWorkerRoleQueryService workerRoleQueryService,
    IManagerWorkerRoleCommandService managerWorkerRoleCommandService) : IAdministratorCommandService
{
    public async Task<int> Handle(SignUpAdministratorCommand command)
    {
        try
        {
            if (await administratorRepository.ExistsByEmailAsync(command.Email))
                throw new EmailAlreadyExistException(command.Email);
            
            // Validate the supervision areas

            var validAreas =
                await workerRoleQueryService.Handle(new GetWorkerRolesByValidationQuery(command.SupervisionAreas));
            
            // Add Admin
            
            await administratorRepository.AddAsync(new Administrator(command.UserName, command.Email, new Role(ERoles.ROLE_MANAGER), command.Name,
                command.PhoneNumber, command.AccountStatus, command.Surname));

            await unitOfWork.CompleteAsync();
            
            var userId = await administratorRepository.FindIdByEmailAsync(command.Email);
            
            // Register Supervision Areas in manager_worker_roles table
            foreach (var area in validAreas)
            {
                await managerWorkerRoleCommandService
                    .Handle(new CreateManagerWorkerRoleCommand(userId, area.Id));
            }
            
            await unitOfWork.CompleteAsync();

            return userId;
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
            var user = await administratorRepository.FindByEmailAsync(command.Email);

            if (user is null)
                throw new EmailDoesntExistException();

            var userCredential = await administratorCredentialRepository.FindByIdAsync(user.Id);

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
                User = user, 
                Token = token
            };
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}