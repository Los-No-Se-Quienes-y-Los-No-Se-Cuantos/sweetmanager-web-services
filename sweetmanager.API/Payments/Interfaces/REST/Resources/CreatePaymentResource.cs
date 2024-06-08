namespace sweetmanager.API.Payments.Interfaces.REST.Resources;

public record CreatePaymentResource(
    string CardNumber,
    string CardHolderName,
    string ExpiryDate,
    string Cvv,
    string ProfileEmail,
    decimal Amount);