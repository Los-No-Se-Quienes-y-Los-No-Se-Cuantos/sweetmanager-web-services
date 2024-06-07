using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Rooms.Domain.Repositories;

public interface IBedroomRepository : IBaseRepository<Bedroom>
{
    Task<IEnumerable<Bedroom>> FindBedroomByStateAsync(string state);
}