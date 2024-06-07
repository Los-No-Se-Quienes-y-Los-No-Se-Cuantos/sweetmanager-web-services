namespace sweetmanager.API.Rooms.Domain.Model.Commands;

public record UpdateBedroomCommand(int TypeBedroomId, int WorkerId, int TotalBeds,
                                   int TotalBathroom, int TotalTelevision, string State);