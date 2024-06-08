namespace sweetmanager.API.Subscriptions.Interfaces.REST.Resources;

public record SubscriptionResource(
    int Id,
    string Title,
    string Price,
    IEnumerable<string> Features
);  