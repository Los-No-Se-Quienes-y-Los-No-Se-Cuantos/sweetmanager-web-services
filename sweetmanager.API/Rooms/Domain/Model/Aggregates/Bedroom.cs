using Humanizer;
using Microsoft.OpenApi.Extensions;
using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Domain.Model.ValueObjects;

namespace sweetmanager.API.Rooms.Domain.Model.Aggregates;

public class Bedroom
{
    public int Id { get; }
    public BedroomInformation Information { get; private set; }
    public ETypeBedroom TypeBedroom { get; private set; }
    public EBedroomStatus BedroomStatus { get; private set; }

    public BedroomPersonnelInformation Personnel { get; private set; }
    
    public string ResourcesRoom => Information.Resources();

    public bool IsBusy => BedroomStatus == EBedroomStatus.Busy;
    
    public Bedroom()
    {
        Information = new BedroomInformation();
    }

    public string TypeBedroomName => TypeBedroom.ToString().Humanize();
    
    public Bedroom(int totalBed, int totalBathroom, int totalTelevision, string description, decimal price)
    {
        Information = new BedroomInformation(totalBed, totalBathroom, totalTelevision, description, price);
    }
    public Bedroom(CreateBedroomCommand command)
    {
        TypeBedroom = command.TypeBedroom == "Royal" ?
            ETypeBedroom.Royal : ETypeBedroom.Standard;
        
        Information = new BedroomInformation(command.TotalBed, command.TotalBathroom, 
            command.TotalTelevision, command.Description, command.Price);
        
        BedroomStatus = command.State == "Busy" ? 
            EBedroomStatus.Busy : EBedroomStatus.NotBusy;
        
        Personnel = new BedroomPersonnelInformation(command.Worker, command.Client);
    }

    public void Update(UpdateBedroomCommand command)
    {
        TypeBedroom = command.TypeBedroom == "Royal" ? 
            ETypeBedroom.Royal : ETypeBedroom.Standard;
        
        Information = new BedroomInformation(command.TotalBed, command.TotalBathroom,
            command.TotalTelevision, command.Description, command.Price);
        
        BedroomStatus = command.State == "Busy" ?
            EBedroomStatus.Busy : EBedroomStatus.NotBusy;
        
        Personnel = new BedroomPersonnelInformation(command.Worker, command.Client);
    }
}