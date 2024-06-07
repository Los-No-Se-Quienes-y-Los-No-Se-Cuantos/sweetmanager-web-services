using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Queries;

namespace sweetmanager.API.Rooms.Domain.Model.Services;

public interface IBedroomQueryService
{
    Task<IEnumerable<Bedroom>> Handle(GetAllBedroomsQuery query);
    Task<Bedroom?> Handle(GetBedroomByIdQuery query);
    Task<IEnumerable<Bedroom>> Handle(GetBedroomByStateQuery query);
}