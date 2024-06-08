
namespace sweetmanager.API.Clients.Domain.Model.Commands
{
    public record CreateClientCommand(
        int Id,
        string Name,
        string LastName,
        int Age,
        string Genre,
        int Phone,
        string Email,
        string State);
}