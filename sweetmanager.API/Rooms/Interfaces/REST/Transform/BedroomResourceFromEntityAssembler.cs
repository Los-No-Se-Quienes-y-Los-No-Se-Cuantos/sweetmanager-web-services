using Microsoft.OpenApi.Extensions;
using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class BedroomResourceFromEntityAssembler
{
    public static BedroomResource ToResourceFromEntity(Bedroom entity){
        return new BedroomResource(entity.Id, entity.TypeBedroomName, 
            entity.Information.Description, entity.Information.Price, entity.Personnel.Worker,
            entity.Personnel.Client, entity.Information.TotalBed, 
            entity.Information.TotalBathroom, entity.Information.TotalTelevision,
            entity.IsBusy
            );
    }
}