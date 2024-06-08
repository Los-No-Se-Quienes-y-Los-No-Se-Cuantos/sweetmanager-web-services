using sweetmanager.API.Subscriptions.Domain.Model.Aggregates;
using sweetmanager.API.Subscriptions.Domain.Model.Command;

namespace sweetmanager.API.Subscriptions.Domain.Services;

public interface ISubscriptionCommandService
{
    Task<Subscription?> Handle(CreateSubscriptionCommand command);
}