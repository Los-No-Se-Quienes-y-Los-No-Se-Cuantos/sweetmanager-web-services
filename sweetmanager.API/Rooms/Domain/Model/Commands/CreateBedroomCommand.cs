namespace sweetmanager.API.Rooms.Domain.Model.Commands;

public record CreateBedroomCommand(int TypeBedroomId, int TotalBed,
                                    int TotalBathroom, int TotalTelevision,
                                    string State);