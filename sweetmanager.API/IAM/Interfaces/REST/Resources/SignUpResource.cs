namespace sweetmanager.API.IAM.Interfaces.REST.Resources;

public record SignUpResource(string UserName, string Email, string Password, string Role);