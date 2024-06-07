namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record CreateBedroomResource(int TypeBedroomId, int WorkerId, int TotalBeds,
                                    int TotalBathroom, int TotalTelevision, string State);