namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record BedroomResource(int TypeBedroomId, int TotalBed, int TotalBathroom,
                              int TotalTelevision, string State);