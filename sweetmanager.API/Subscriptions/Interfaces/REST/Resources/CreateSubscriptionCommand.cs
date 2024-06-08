namespace sweetmanager.API.Subscriptions.Interfaces.REST.Resources;

public record CreateSubscriptionCommand(
    string Title,
    double Price,
    IEnumerable<string> Features
);