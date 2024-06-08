using sweetmanager.API.Shared.Domain.Repositories;
using sweetmanager.API.Supply.Domain.Model.Aggregates;

namespace sweetmanager.API.Supply.Domain.Repositories;

public interface ISupplyRepository : IBaseRepository<Model.Aggregates.Supply>
{
    Task<Model.Aggregates.Supply> GetSupplySourceByIdAsync(int id);
}