using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication.Work;

public record SignUpWorkerResource(string UserName, string Email, string Password, string PhoneNumber, 
    string Surname, string Name, string WorkArea, bool ActiveAccount);