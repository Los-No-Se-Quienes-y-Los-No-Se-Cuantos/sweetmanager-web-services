using sweetmanager.API.Payments.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Payments.Domain.Repositories;

public interface IPaymentRepository: IBaseRepository<Payment>
{
    Task<IEnumerable<Payment>> FindPaymentByEmailAsync(string email);
}