using sweetmanager.API.Payments.Domain.Model.Aggregates;
using sweetmanager.API.Payments.Domain.Model.Command;

namespace sweetmanager.API.Payments.Domain.Services;

public interface IPaymentCommandService
{

    Task<Payment> Handle(CreatePaymentCommand command);
}