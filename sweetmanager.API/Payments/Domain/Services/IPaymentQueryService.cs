using sweetmanager.API.Payments.Domain.Model.Aggregates;
using sweetmanager.API.Payments.Domain.Model.Queries;

namespace sweetmanager.API.Payments.Domain.Services;

public interface IPaymentQueryService
{

    Task<Payment?> Handle(GetPaymentByIdQuery query);

    Task<IEnumerable<Payment>> Handle(GetAllPaymentByEmailQuery query);

    Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query);
}