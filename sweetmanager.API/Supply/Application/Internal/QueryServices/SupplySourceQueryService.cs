using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Domain.Model.Queries;
using sweetmanager.API.Supply.Domain.Repositories;
using sweetmanager.API.Supply.Domain.Services;

namespace sweetmanager.API.Supply.Application.Internal.QueryServices;

public class SupplySourceQueryService(ISupplySourceRepository sourceRepository):  ISupplySourceQueryService
{
    public async Task<IEnumerable<SupplySource>> Handle(GetAllSuppliesSourceQuery query)
    {
        return await sourceRepository.ListAsync();
    }
    public async Task<SupplySource?> Handle(GetSupplySourceByIdQuery query)
    {
        return await sourceRepository.GetSupplySourceByIdAsync(query.SupplyId);
    }
    
}