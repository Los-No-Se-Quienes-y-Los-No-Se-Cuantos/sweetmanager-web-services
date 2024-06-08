using sweetmanager.API.Subscriptions.Domain.Model.Aggregates;
using sweetmanager.API.Subscriptions.Interfaces.REST.Resources;

namespace sweetmanager.API.Subscriptions.Interfaces.REST.Transforms;

public class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription entity)
    {
        return new SubscriptionResource(entity.Id, entity.Title, entity.Price.ToString(), entity.Features);
    }
}