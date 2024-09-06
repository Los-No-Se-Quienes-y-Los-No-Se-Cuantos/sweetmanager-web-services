namespace sweetmanager.API.Rooms.Domain.Model.Commands;

public record CreateBedroomCommand(string TypeBedroom, int TotalBed, int TotalBathroom,
                                   int TotalTelevision, string State, string Description, string Worker, string Client, decimal Price, string BedroomState);