using sweetmanager.API.Shared.Domain.Repositories;
using sweetmanager.API.Subscriptions.Domain.Model.Aggregates;

namespace sweetmanager.API.Subscriptions.Domain.Repositories;

public interface ISubscriptionRepository: IBaseRepository<Subscription>
{
    Task<Subscription> FindByTitleAsync(String title);
}