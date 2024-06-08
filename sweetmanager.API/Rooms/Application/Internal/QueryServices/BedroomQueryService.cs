using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Queries;
using sweetmanager.API.Rooms.Domain.Repositories;
using sweetmanager.API.Rooms.Domain.Services;

namespace sweetmanager.API.Rooms.Application.Internal.QueryServices;

public class BedroomQueryService(IBedroomRepository bedroomRepository) : IBedroomQueryService
{
    public async Task<IEnumerable<Bedroom>> Handle(GetAllBedroomsQuery query)
    {
        return await bedroomRepository.ListAsync();
    }

    public async Task<Bedroom?> Handle(GetBedroomByIdQuery query)
    {
        return await bedroomRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Bedroom>> Handle(GetBedroomByStateQuery query)
    {
        return await bedroomRepository.FindBedroomByStateAsync(query.State);
    }
}