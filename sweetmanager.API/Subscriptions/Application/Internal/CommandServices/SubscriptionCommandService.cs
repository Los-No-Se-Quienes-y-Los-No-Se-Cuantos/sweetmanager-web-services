using sweetmanager.API.Shared.Domain.Repositories;
using sweetmanager.API.Subscriptions.Domain.Model.Aggregates;
using sweetmanager.API.Subscriptions.Domain.Model.Command;
using sweetmanager.API.Subscriptions.Domain.Repositories;
using sweetmanager.API.Subscriptions.Domain.Services;

namespace sweetmanager.API.Subscriptions.Application.Internal.CommandServices;

public class SubscriptionCommandService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork)
: ISubscriptionCommandService
{
    public async Task<Subscription> Handle(CreateSubscriptionCommand command)
    {
        var subscription = await subscriptionRepository.FindByTitleAsync(command.Title);
        if (subscription != null)
        {
            throw new Exception("Subscription with the same title already exists.");
        }

        subscription = new Subscription(command);
        await subscriptionRepository.AddAsync(subscription);
        await unitOfWork.CompleteAsync();
        return subscription;
    }
}