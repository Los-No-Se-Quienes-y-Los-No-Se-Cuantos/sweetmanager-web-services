namespace sweetmanager.API.Subscriptions.Domain.Model.Command;

public record CreateSubscriptionCommand(
    String Title,
    Double Price,
    IEnumerable<String> Features
    );