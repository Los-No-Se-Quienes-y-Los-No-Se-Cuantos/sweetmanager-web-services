namespace sweetmanager.API.Supply.Domain.Model.Commands;

public record CreateSupplyCommand(string Product, int Quantity, string Address, string ExpireDate, decimal Price);