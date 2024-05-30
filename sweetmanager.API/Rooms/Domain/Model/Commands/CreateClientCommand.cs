namespace sweetmanager.API.Rooms.Domain.Model.Commands;

public record CreateClientCommand(string FirstName, string LastName, int Age, string Genre, int Phone, string Email, string State);