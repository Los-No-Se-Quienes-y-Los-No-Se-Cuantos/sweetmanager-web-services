using sweetmanager.API.IAM.Domain.Model.ValueObjects;

namespace sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Worker;

public record SignUpWorkerCommand(string UserName, string Email, string Password, string PhoneNumber, 
    string Surname, string Name, string WorkArea, bool ActiveAccount);