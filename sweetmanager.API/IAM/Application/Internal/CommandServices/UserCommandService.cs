using sweetmanager.API.IAM.Application.Internal.OutboundContext;
using sweetmanager.API.IAM.Domain.Model.Aggregates;
using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Entities;
using sweetmanager.API.IAM.Domain.Model.Exceptions;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Repositories;
using sweetmanager.API.IAM.Domain.Services;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    IUserCredentialRepository userCredentialRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IHashingService hashingService
) : IUserCommandService
{
    public async Task<User?> Handle(SignUpCommand command)
    {
        try
        {
            if (userRepository.ExistsByEmail(command.Email))
                throw new Exception($"Email {command.Email} is already taken");

            if (!command.Role.Equals("ROLE_MANAGER") && !command.Role.Equals("ROLE_WORKER"))
                throw new RoleNameMustExistException();
            
            Enum.TryParse(command.Role, out ERoles role);
        
            var user = new User(command.UserName,  command.Email, new Role(role));
            
            await userRepository.AddAsync(user);
            
            await unitOfWork.CompleteAsync();
            
            return user;
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the user: {e.Message}");
        }
    }

    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByEmailAsync(command.Email);
    
        if(user is null)
            throw new Exception("Invalid email");
        
        var userCredential = await userCredentialRepository.FindByUserIdAsync(user.Id);
        
        if (!hashingService.
                VerifyHash(command.Password, userCredential!.Argon2IdUserHash[..24], userCredential!.Argon2IdUserHash[24..]))
            throw new Exception("Invalid password");

        var token = tokenService.GenerateToken(new {
            Id = user.Id,
            PasswordHash = userCredential.Argon2IdUserHash,
            Role = user.Role
        });

        return (user, token);
    }
}