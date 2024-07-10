namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record CreateBedroomResource(string Name, int TotalBed, int TotalBathroom,
                                    int TotalTelevision, string State, string Description, string Worker, string Client, decimal Price);