using sweetmanager.API.Payments.Domain.Model.Command;
using sweetmanager.API.Payments.Domain.Model.ValueObjects;

namespace sweetmanager.API.Payments.Domain.Model.Aggregates;

public partial class Payment
{
    public int Id { get; private set; }

    public PaymentCardInfo CardInfo { get; private set; }

    public string Email { get; private set; }

    public ProfileId ProfileId { get; private set; }

    public decimal Amount { get; private set; }
    
    public Payment() {}

    public Payment(CreatePaymentCommand command)
    {
        this.CardInfo =
            new PaymentCardInfo(command.CardNumber, command.CardHolderName, command.ExpiryDate, command.Cvv);
        this.Email = command.ProfileEmail;
        this.ProfileId = new ProfileId(0);
        this.Amount = command.Amount;
    }

    public Payment(CreatePaymentCommand command, int profileId)
    {
        this.CardInfo =
            new PaymentCardInfo(command.CardNumber, command.CardHolderName, command.ExpiryDate, command.Cvv);
        this.Email = command.ProfileEmail;
        this.ProfileId = new ProfileId(profileId);
        this.Amount = command.Amount;
    }
}