namespace sweetmanager.API.Rooms.Domain.Model.Commands;

public record CreateBookingCommand(int ClientId, int BedroomId, DateTime StartDate, DateTime FinalDate, float TotalPrice, string State);