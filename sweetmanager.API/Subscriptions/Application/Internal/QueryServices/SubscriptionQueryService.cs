using sweetmanager.API.Subscriptions.Domain.Model.Aggregates;
using sweetmanager.API.Subscriptions.Domain.Model.Query;
using sweetmanager.API.Subscriptions.Domain.Repositories;
using sweetmanager.API.Subscriptions.Domain.Services;

namespace sweetmanager.API.Subscriptions.Application.Internal.QueryServices;

public class SubscriptionQueryService(ISubscriptionRepository subscriptionRepository) :
    ISubscriptionQueryService
{
    public async Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionQuery query)
    {
        return await subscriptionRepository.ListAsync();
    }
}