namespace sweetmanager.API.Clients.Interfaces.REST.Resources
{
    public record CreateClientResource(int Id, string Name, string LastName, int Age, string Genre, int Phone, string Email, string State);
}