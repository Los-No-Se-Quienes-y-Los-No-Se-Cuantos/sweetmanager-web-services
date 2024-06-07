using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Queries;

namespace sweetmanager.API.Rooms.Domain.Model.Services;

public interface IBedroomQueryService
{
    Task<Bedroom> Handle(GetAllBedroomsQuery query);
    Task<Bedroom> Handle(GetBedroomByIdQuery query);
    Task<Bedroom> Handle(GetBedroomByStateQuery query);
}