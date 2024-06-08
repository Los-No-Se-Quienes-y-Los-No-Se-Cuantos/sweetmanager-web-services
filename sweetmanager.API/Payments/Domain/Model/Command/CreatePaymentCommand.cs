namespace sweetmanager.API.Payments.Domain.Model.Command;

public record CreatePaymentCommand(
    string CardNumber,
    string CardHolderName,
    string ExpiryDate,
    string Cvv,
    string ProfileEmail,
    decimal Amount
    );