namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record BookingResource(int ClientId, int BedroomId, string Detail, string State);