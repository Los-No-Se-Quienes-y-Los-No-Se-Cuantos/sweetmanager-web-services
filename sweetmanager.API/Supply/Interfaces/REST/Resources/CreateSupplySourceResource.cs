namespace sweetmanager.API.Supply.Interfaces.REST.Resources;

public record CreateSupplySourceResource(string Product, int Quantity, string Address, string ExpireDate, decimal Price);