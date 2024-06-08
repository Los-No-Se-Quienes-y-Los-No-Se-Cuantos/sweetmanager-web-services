using sweetmanager.API.Supply.Domain.Model.Queries;
using sweetmanager.API.Supply.Domain.Repositories;
using sweetmanager.API.Supply.Domain.Services;

namespace sweetmanager.API.Supply.Application.Internal.QueryServices;

public class SupplyQueryService(ISupplyRepository repository):  ISupplyQueryService
{
    public async Task<IEnumerable<Domain.Model.Aggregates.Supply>> Handle(GetAllSuppliesQuery query)
    {
        return await repository.ListAsync();
    }
    public async Task<Domain.Model.Aggregates.Supply?> Handle(GetSupplyByIdQuery query)
    {
        return await repository.GetSupplySourceByIdAsync(query.SupplyId);
    }
    
}