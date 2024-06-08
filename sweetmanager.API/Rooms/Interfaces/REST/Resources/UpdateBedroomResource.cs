namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record UpdateBedroomResource(int Id, int TypeBedroomId, int TotalBed,
                                    int TotalBathroom, int TotalTelevision, string State);