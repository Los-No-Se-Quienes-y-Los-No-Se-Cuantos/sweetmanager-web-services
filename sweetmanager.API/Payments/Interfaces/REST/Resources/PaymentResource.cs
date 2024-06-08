namespace sweetmanager.API.Payments.Interfaces.REST.Resources;

public record PaymentResource(
    int Id,
    int IdProfile,
    string TitularName,
    string TargetAccount,
    string ExpirationDate,
    string Cvv,
    string CardNumber,
    decimal Amount
);