using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Domain.Model.Queries;

namespace sweetmanager.API.Supply.Domain.Services;

public interface ISupplySourceQueryService
{
    Task<IEnumerable<SupplySource>> Handle(GetAllSuppliesSourceQuery query);
    Task<SupplySource?> Handle(GetSupplySourceByIdQuery query);
}