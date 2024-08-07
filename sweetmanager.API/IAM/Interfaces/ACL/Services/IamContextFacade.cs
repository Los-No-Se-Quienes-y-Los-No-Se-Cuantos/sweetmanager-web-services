using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Exceptions;
using sweetmanager.API.IAM.Domain.Model.Queries;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Services;

namespace sweetmanager.API.IAM.Interfaces.ACL.Services;

public class IamContextFacade(IUserCommandService userCommandService, IUserQueryService userQueryService) : IIamContextFacade
{
    public async Task<int> CreateUser(string username, string password, string email, string role)
    {
        try
        {
            if (!role.Equals("ROLE_MANAGER") && !role.Equals("ROLE_WORKER"))
                throw new RoleNameMustExistException();
        
            var signUpCommand = new SignUpCommand(username, email , password, role);
        
            await userCommandService.Handle(signUpCommand);
        
            var getUserByUsernameQuery = new GetUserByEmailQuery(username);
        
            var result = await userQueryService.Handle(getUserByUsernameQuery);
        
            return result?.Id ?? 0;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<int> FetchUserIdByUsername(string username)
    {
        try
        {
            var getUserByUsernameQuery = new GetUserByEmailQuery(username);

            var result = await userQueryService.Handle(getUserByUsernameQuery);

            return result?.Id ?? 0;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<string> FetchUsernameByUserId(int userId)
    {
        try
        {
            var getUserByIdQuery = new GetUserByIdQuery(userId);
           
            var result = await userQueryService.Handle(getUserByIdQuery);
            
            return result?.Username ?? string.Empty;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}