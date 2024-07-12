
namespace sweetmanager.API.Clients.Domain.Model.Commands
{
    public record CreateClientCommand(
        string Name,
        string LastName,
        int Age,
        string Genre,
        string Phone,
        string Email,
        string State);
}