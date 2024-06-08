namespace sweetmanager.API.Subscriptions.Interfaces.REST.Resources;

public record CreateSubscriptionCommandResource(
    string Title,
    double Price,
    IEnumerable<string> Features
);