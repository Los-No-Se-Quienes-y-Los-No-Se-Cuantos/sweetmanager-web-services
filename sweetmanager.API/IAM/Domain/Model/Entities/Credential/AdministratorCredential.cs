using System.ComponentModel.DataAnnotations;
using sweetmanager.API.IAM.Domain.Model.Aggregates.Management;

using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Credential;

namespace sweetmanager.API.IAM.Domain.Model.Entities.Credential;

public sealed partial class AdministratorCredential
{
    public int Id { get; private set; }
    
    public int AdminId { get; private set;  }

    [MaxLength(50)]
    public string Argon2IdUserHash { get; private set; }

    public Administrator Admin { get; private set; } = null!;
    
    public AdministratorCredential()
    {
        this.Id = 0;
        
        this.AdminId = 0;
        
        this.Argon2IdUserHash = string.Empty;
    }

    public AdministratorCredential(int userId, string argon2IdUserHash)
    {
        this.AdminId = userId;
        
        this.Argon2IdUserHash = argon2IdUserHash;
    }

    public AdministratorCredential(CreateUserCredentialCommand command)
    {
        this.AdminId = command.UserId;
        
        this.Argon2IdUserHash = command.Argon2IdUserHash;
    }
}