namespace sweetmanager.API.Supply.Interfaces.REST.Resources;

public record CreateSupplyResource(string Product, int Quantity, string Address, string ExpireDate, decimal Price);