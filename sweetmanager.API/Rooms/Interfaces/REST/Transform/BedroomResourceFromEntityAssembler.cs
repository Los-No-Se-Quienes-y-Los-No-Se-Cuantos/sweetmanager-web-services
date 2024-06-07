using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class BedroomResourceFromEntityAssembler
{
    public static BedroomResource ToResourceFromEntity(Bedroom entity){
        return new BedroomResource(entity.TypeBedroomId, entity.TotalBed,
            entity.TotalBathroom, entity.TotalTelevision, entity.State);
    }
}