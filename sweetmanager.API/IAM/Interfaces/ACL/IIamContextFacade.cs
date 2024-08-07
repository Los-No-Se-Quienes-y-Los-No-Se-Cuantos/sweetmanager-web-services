namespace sweetmanager.API.IAM.Interfaces.ACL;

public interface IIamContextFacade
{
    Task<int> CreateUser(string username, string password, string email, string role);
    
    Task<int> FetchUserIdByUsername(string username);
    
    Task<string> FetchUsernameByUserId(int userId);
}