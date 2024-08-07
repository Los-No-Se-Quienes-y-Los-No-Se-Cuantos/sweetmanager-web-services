using sweetmanager.API.IAM.Domain.Model.Aggregates;
using sweetmanager.API.IAM.Domain.Model.Commands;

namespace sweetmanager.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(SignUpCommand command);
    
    Task<(User user, string token)> Handle(SignInCommand command);
}