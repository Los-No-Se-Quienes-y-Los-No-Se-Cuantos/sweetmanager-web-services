using sweetmanager.API.Subscriptions.Domain.Model.Command;

namespace sweetmanager.API.Subscriptions.Domain.Model.Aggregates;

public class Subscription
{
    public int Id { get; private set; }

    public String Title { get; private set; }

    public Double Price { get; private set; }

    public IEnumerable<String> Features { get; private set; }

    protected Subscription()
    {
        this.Title = String.Empty;
        this.Price = 0.0;
        this.Features = new List<String>();
    }

    public Subscription(CreateSubscriptionCommand command)
    {
        this.Title = command.Title;
        this.Price = command.Price;
        this.Features = command.Features;
    }
}