using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Payments.Domain.Model.Aggregates;
using sweetmanager.API.Payments.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.Payments.Infrastructure.Persistence.EFC.Repositories;

public class PaymentRepository(AppDbContext appDbContext): BaseRepository<Payment>(appDbContext), IPaymentRepository
{
    public async Task<IEnumerable<Payment>> FindPaymentByEmailAsync(string email)
    {
        return await Context.Set<Payment>().Where(p => p.Email == email).ToListAsync();
    }
}