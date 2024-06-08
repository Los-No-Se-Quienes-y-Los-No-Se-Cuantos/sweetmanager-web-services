using Microsoft.OpenApi.Extensions;
using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;

namespace sweetmanager.API.Rooms.Interfaces.REST.Transform;

public class BedroomResourceFromEntityAssembler
{
    public static BedroomResource ToResourceFromEntity(Bedroom entity){
        return new BedroomResource(entity.TypeBedroom.GetDisplayName(), entity.ResourcesRoom, entity.BedroomStatus.GetDisplayName());
    }
}