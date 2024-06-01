using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Interfaces.REST.Resources;

namespace sweetmanager.API.Supply.Interfaces.REST.Transform;

public class SupplySourceResourceFromEntityAssembler
{
    public static SupplySourceResource ToResourceFromEntity(SupplySource entity)
    {
        return new SupplySourceResource(entity.Id, entity.Product, entity.Quantity, entity.Address, entity.ExpireDate, entity.Price);
    }
}