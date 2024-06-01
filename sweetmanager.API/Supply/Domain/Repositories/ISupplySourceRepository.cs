using sweetmanager.API.Shared.Domain.Repositories;
using sweetmanager.API.Supply.Domain.Model.Aggregates;

namespace sweetmanager.API.Supply.Domain.Repositories;

public interface ISupplySourceRepository : IBaseRepository<SupplySource>
{
    Task<SupplySource> GetSupplySourceByIdAsync(int id);
}