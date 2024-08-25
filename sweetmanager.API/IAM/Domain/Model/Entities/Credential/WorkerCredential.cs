using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Credential;

namespace sweetmanager.API.IAM.Domain.Model.Entities.Credential;

public sealed partial class WorkerCredential(int userId, string argon2IdUserHash)
{
    public int Id { get; private set; }
    
    public int WorkerId { get; private set;  } = userId;

    public string Argon2IdUserHash { get; private set; } = argon2IdUserHash;

    public Worker Worker { get; private set; } = null!;
    
    public WorkerCredential() : this(0, string.Empty)
    {
        this.Id = 0;
    }

    public WorkerCredential(CreateUserCredentialCommand command) : this(command.UserId, command.Argon2IdUserHash)
    {
    }
}