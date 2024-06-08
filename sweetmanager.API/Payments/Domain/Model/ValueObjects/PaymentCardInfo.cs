namespace sweetmanager.API.Payments.Domain.Model.ValueObjects;

public record PaymentCardInfo(
    string CardNumber,
    string CardHolderName,
    string ExpiryDate,
    string Cvv
);