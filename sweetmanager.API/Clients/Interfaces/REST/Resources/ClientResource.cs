namespace sweetmanager.API.Clients.Interfaces.REST.Resources;

public record ClientResource(int Id, string Name, string LastName, int Age, 
    string Genre, string Email, string State);