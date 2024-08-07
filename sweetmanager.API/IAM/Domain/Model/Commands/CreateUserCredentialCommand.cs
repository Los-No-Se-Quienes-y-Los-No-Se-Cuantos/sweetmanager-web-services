namespace sweetmanager.API.IAM.Domain.Model.Commands;

public record CreateUserCredentialCommand(int UserId, string Argon2IdUserHash);