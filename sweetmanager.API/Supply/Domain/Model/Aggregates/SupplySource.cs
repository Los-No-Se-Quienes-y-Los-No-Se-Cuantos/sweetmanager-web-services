using sweetmanager.API.Supply.Domain.Model.Commands;

namespace sweetmanager.API.Supply.Domain.Model.Aggregates;

public partial class SupplySource
{
    public int Id { get; private set; }
    public string Product { get; private set; }
    public int Quantity { get; private set; }
    public string Address { get; private set; }
    public string ExpireDate { get; private set; }
    public decimal Price { get; private set; }
    
    public SupplySource()
    {
        this.Product = string.Empty;
        this.Quantity = 0;
        this.Address = string.Empty;
        this.ExpireDate = string.Empty;
        this.Price = 0;
    }
    public SupplySource(CreateSupplySourceCommand command)
    {
        this.Product = command.Product;
        this.Quantity = command.Quantity;
        this.Address = command.Address;
        this.ExpireDate = command.ExpireDate;
        this.Price = command.Price;
    }
    
    public DateTimeOffset? UpdatedDate { get; set; }
}