using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Interfaces.REST.Resources;

namespace sweetmanager.API.Supply.Interfaces.REST.Transform;

public class SupplyResourceFromEntityAssembler
{
    public static SupplyResource ToResourceFromEntity(Domain.Model.Aggregates.Supply entity)
    {
        return new SupplyResource(entity.Id, entity.Product, entity.Quantity, entity.Address, entity.ExpireDate, entity.Price);
    }
}