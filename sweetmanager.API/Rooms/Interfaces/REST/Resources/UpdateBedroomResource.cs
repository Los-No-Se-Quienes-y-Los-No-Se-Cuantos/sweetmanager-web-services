namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record UpdateBedroomResource(int Id, string Name, int TotalBed,
    int TotalBathroom, int TotalTelevision, string State,
    string Description, string Worker, string Client, decimal Price);