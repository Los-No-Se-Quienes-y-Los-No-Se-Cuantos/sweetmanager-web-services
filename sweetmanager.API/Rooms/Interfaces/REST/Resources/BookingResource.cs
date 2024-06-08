namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record BookingResource(int ClientId, int BedroomId, DateTime StartDate,
                              DateTime FinalDate, float TotalPrice, String State);