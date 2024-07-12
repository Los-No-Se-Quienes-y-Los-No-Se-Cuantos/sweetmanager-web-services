namespace sweetmanager.API.IAM.Domain.Model.Commands;

public record SignUpCommand(string UserName, string Email, string Password);