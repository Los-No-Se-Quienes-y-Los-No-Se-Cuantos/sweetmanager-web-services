using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Domain.Model.Queries;

namespace sweetmanager.API.Supply.Domain.Services;

public interface ISupplyQueryService
{
    Task<IEnumerable<Model.Aggregates.Supply>> Handle(GetAllSuppliesQuery query);
    Task<Model.Aggregates.Supply?> Handle(GetSupplyByIdQuery query);
}