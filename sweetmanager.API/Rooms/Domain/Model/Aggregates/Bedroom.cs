using Humanizer;
using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Domain.Model.ValueObjects;

namespace sweetmanager.API.Rooms.Domain.Model.Aggregates;

public class Bedroom
{
    public int Id { get; }
    public BedroomInformation Information { get; private set; }
    public ETypeBedroom TypeBedroom { get; private set; }
    public EBedroomStatus BedroomStatus { get; private set; }

    public string ResourcesRoom => Information.Resources();

    public Bedroom()
    {
        Information = new BedroomInformation();
    }
    public Bedroom(int totalBed, int totalBathroom, int totalTelevision, string state)
    {
        Information = new BedroomInformation(totalBed, totalBathroom, totalTelevision);

        if (state == "Busy") BedroomStatus = EBedroomStatus.Busy;
        else BedroomStatus = EBedroomStatus.NotBusy;
    }
    public Bedroom(CreateBedroomCommand command)
    {
        if (command.TypeBedroom == "Royal") TypeBedroom = ETypeBedroom.Royal;
        else TypeBedroom = ETypeBedroom.Standard;
        
        Information = new BedroomInformation(command.TotalBed, command.TotalBathroom, command.TotalTelevision);
        
        if (command.State == "Busy") BedroomStatus = EBedroomStatus.Busy;
        else BedroomStatus = EBedroomStatus.NotBusy;
    }

    public Bedroom(UpdateBedroomCommand command)
    {
        if (command.TypeBedroom == "Royal") TypeBedroom = ETypeBedroom.Royal;
        else TypeBedroom = ETypeBedroom.Standard;
        
        Information = new BedroomInformation(command.TotalBed, command.TotalBathroom, command.TotalTelevision);
        
        if (command.State == "Busy") BedroomStatus = EBedroomStatus.Busy;
        else BedroomStatus = EBedroomStatus.NotBusy;
    }
}