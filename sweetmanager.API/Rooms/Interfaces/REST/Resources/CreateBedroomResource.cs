namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record CreateBedroomResource(string TypeBedroom, int TotalBed, int TotalBathroom,
                                    int TotalTelevision, string State);