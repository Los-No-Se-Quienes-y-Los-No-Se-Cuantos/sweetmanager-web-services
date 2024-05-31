using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using sweetmanager.API.Subscriptions.Domain.Model.Aggregates;
using sweetmanager.API.Subscriptions.Domain.Repositories;

namespace sweetmanager.API.Subscriptions.Infrastructure.Persistence.EFC;

public class SubscriptionRepository: BaseRepository<Subscription>, ISubscriptionRepository
{
    public SubscriptionRepository(AppDbContext context) : base(context)
    {
    }
}