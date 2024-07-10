namespace sweetmanager.API.Rooms.Interfaces.REST.Resources;

public record BedroomResource(int Id, string Name, string Description, decimal Price,
    string Worker, string Client, int TotalBeds, int TotalBathrooms, int TotalTelevision,
    bool IsBusy);