namespace sweetmanager.API.Clients.Interfaces.REST.Resources
{
    public record CreateClientResource(string Name, string LastName, int Age, string Genre, string Phone, string Email, string State);
}