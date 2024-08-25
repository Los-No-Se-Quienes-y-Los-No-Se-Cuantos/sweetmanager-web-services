namespace sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Manager;

public record SignUpAdministratorCommand(string UserName, string Email, string Password, ICollection<string> SupervisionAreas, 
    string PhoneNumber, string Name, string Surname, string AccountStatus);