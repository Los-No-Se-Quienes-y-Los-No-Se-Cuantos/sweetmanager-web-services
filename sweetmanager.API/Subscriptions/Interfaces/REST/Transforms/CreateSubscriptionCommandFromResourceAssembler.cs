using sweetmanager.API.Subscriptions.Domain.Model.Command;
using sweetmanager.API.Subscriptions.Interfaces.REST.Resources;

namespace sweetmanager.API.Subscriptions.Interfaces.REST.Transforms;

public class CreateSubscriptionCommandFromResourceAssembler
{
    
    public static CreateSubscriptionCommand ToCommandFromResource(CreateSubscriptionCommandResource resource)
    {
        return new CreateSubscriptionCommand(
            resource.Title,
            resource.Price,
            resource.Features
        );
    }
}