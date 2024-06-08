namespace sweetmanager.API.Supply.Interfaces.REST.Resources;

public record SupplyResource(int Id, string Product, int Quantity, string Address, string ExpireDate, decimal Price);