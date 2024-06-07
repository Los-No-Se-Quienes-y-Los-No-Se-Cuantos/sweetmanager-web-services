namespace sweetmanager.API.Rooms.Domain.Model.Commands;

public record UpdateBedroomCommand(int Id, int TypeBedroomId, int TotalBed,
                                   int TotalBathroom, int TotalTelevision, string State);