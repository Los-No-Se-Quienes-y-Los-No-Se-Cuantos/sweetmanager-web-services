using sweetmanager.API.IAM.Domain.Model.Aggregates;
using sweetmanager.API.IAM.Domain.Model.Commands;

namespace sweetmanager.API.IAM.Domain.Model.Entities;


public sealed partial class UserCredential
{
    public int Id { get; private set; }
    
    public int UserId { get; private set;  }

    public string Argon2IdUserHash { get; private set; }

    public User User { get; private set; } = null!;

    public UserCredential()
    {
        this.Id = 0;
        
        this.UserId = 0;
        
        this.Argon2IdUserHash = string.Empty;
    }

    public UserCredential(int userId, string argon2IdUserHash)
    {
        this.UserId = userId;
        
        this.Argon2IdUserHash = argon2IdUserHash;
    }

    public UserCredential(CreateUserCredentialCommand command)
    {
        this.UserId = command.UserId;
        
        this.Argon2IdUserHash = command.Argon2IdUserHash;
    }
}