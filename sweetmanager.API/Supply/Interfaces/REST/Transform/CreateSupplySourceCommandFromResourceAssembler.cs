using sweetmanager.API.Supply.Domain.Model.Commands;
using sweetmanager.API.Supply.Interfaces.REST.Resources;

namespace sweetmanager.API.Supply.Interfaces.REST.Transform;

public record CreateSupplySourceCommandFromResourceAssembler()
{
    public static CreateSupplySourceCommand ToCommandFromResource(CreateSupplySourceResource resource)
    {
        return new CreateSupplySourceCommand(resource.Product, resource.Quantity, resource.Address, resource.ExpireDate, resource.Price);
    }
}