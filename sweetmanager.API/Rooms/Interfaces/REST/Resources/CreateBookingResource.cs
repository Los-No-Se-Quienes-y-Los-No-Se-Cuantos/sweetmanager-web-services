namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record CreateBookingResource(int ClientId, int BedroomId, DateTime StartDate,
                                    DateTime FinalDate, float TotalPrice, string State);