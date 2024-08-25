namespace sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication;

public record SignInResource(string Email, string Password, string Role);