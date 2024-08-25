namespace sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication.Work;

public record WorkerResource(string Username, string Email, string WorkArea, bool ActiveAccount, string PhoneNumber, string Name, string Surname);