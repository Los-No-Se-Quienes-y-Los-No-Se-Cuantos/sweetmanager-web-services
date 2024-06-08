using sweetmanager.API.Subscriptions.Domain.Model.Aggregates;
using sweetmanager.API.Subscriptions.Domain.Model.Query;

namespace sweetmanager.API.Subscriptions.Domain.Services;

public interface ISubscriptionQueryService
{

    Task<IEnumerable<Subscription>> Handle(GetAllSubscriptionQuery query);

}