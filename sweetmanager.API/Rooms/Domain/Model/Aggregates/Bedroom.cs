using sweetmanager.API.Rooms.Domain.Model.Commands;

namespace sweetmanager.API.Rooms.Domain.Model.Aggregates;

public partial class Bedroom
{
    public int Id { get; }
    public int TypeBedroomId { get; private set; }
    public int TotalBed { get; private set; }
    public int TotalBathroom { get; private set; }
    public int TotalTelevision { get; private set; }
    public string State { get; private set; }

    public Bedroom()
    {
        TypeBedroomId = 0;
        TotalBed = 0;
        TotalBathroom = 0;
        TotalTelevision = 0;
        State = string.Empty;
    }
    public Bedroom(int typeBedroomId, int workerId, int totalBed,
        int totalBathroom, int totalTelevision, string state)
    {
        TypeBedroomId = typeBedroomId;
        TotalBed = totalBed;
        TotalBathroom = totalBathroom;
        TotalTelevision = totalTelevision;
        State = state;
    }
    public Bedroom(CreateBedroomCommand command)
    {
        TypeBedroomId = command.TypeBedroomId;
        TotalBed = command.TotalBeds;
        TotalBathroom = command.TotalBathroom;
        TotalTelevision = command.TotalTelevision;
        State = command.State;
    }
}