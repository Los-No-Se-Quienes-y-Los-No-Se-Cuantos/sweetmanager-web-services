using sweetmanager.API.Payments.Domain.Model.Aggregates;
using sweetmanager.API.Payments.Interfaces.REST.Resources;

namespace sweetmanager.API.Payments.Interfaces.REST.Transforms;

public class PaymentResourceFromEntityAssembler
{
    public static PaymentResource ToResourceFromEntity(Payment entity)
    {
        return new PaymentResource(
            entity.Id,
            entity.ProfileId.ProfileId,
            entity.CardInfo.CardHolderName,
            entity.CardInfo.CardNumber,
            entity.CardInfo.ExpiryDate,
            entity.CardInfo.Cvv,
            entity.CardInfo.CardNumber,
            entity.Amount
        );
    }
}