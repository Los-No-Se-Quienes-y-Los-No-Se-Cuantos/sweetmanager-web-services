namespace sweetmanager.API.Supply.Interfaces.REST.Resources;

public record SupplySourceResource(int Id, string Product, int Quantity, string Address, string ExpireDate, decimal Price);