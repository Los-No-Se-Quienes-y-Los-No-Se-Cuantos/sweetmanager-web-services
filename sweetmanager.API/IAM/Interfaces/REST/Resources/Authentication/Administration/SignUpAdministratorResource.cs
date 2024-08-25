
namespace sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication.Administration;

public record SignUpAdministratorResource(string UserName, string Email, string Password, ICollection<string> SupervisionAreas, 
    string PhoneNumber, string Name, string Surname, string AccountStatus);