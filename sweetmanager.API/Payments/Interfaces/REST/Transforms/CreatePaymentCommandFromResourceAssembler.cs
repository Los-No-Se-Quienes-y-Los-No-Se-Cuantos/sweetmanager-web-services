using sweetmanager.API.Payments.Domain.Model.Command;
using sweetmanager.API.Payments.Interfaces.REST.Resources;

namespace sweetmanager.API.Payments.Interfaces.REST.Transforms;

public class CreatePaymentCommandFromResourceAssembler
{
    public static CreatePaymentCommand ToCommandFromResource(CreatePaymentResource resource)
    {
        return new CreatePaymentCommand(
            resource.CardNumber,
            resource.CardHolderName,
            resource.ExpiryDate,
            resource.Cvv,
            resource.ProfileEmail,
            resource.Amount
        );
    }
}