using sweetmanager.API.Payments.Domain.Model.Aggregates;
using sweetmanager.API.Payments.Domain.Model.Queries;
using sweetmanager.API.Payments.Domain.Repositories;
using sweetmanager.API.Payments.Domain.Services;

namespace sweetmanager.API.Payments.Application.Internal.QueryService;

public class PaymentQueryService(IPaymentRepository paymentRepository): IPaymentQueryService
{
    public async Task<Payment?> Handle(GetPaymentByIdQuery query)
    {
        return await paymentRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentByEmailQuery query)
    {
        return await paymentRepository.FindPaymentByEmailAsync(query.Email);
    }

    public async Task<IEnumerable<Payment>> Handle(GetAllPaymentsQuery query)
    {
        return await paymentRepository.ListAsync();
    }
}