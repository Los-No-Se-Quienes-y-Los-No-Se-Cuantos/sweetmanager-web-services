using sweetmanager.API.Supply.Domain.Model.Commands;
using sweetmanager.API.Supply.Interfaces.REST.Resources;

namespace sweetmanager.API.Supply.Interfaces.REST.Transform;

public record CreateSupplyCommandFromResourceAssembler()
{
    public static CreateSupplyCommand ToCommandFromResource(CreateSupplyResource resource)
    {
        return new CreateSupplyCommand(resource.Product, resource.Quantity, resource.Address, resource.ExpireDate, resource.Price);
    }
}