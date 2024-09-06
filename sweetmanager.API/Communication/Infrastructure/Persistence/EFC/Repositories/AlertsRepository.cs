using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Communication.Domain.Model.Aggregates.Alerts;
using sweetmanager.API.Communication.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.Communication.Infrastructure.Persistence.EFC.Repositories;

internal class AlertsRepository(AppDbContext context) : BaseRepository<Alerts>(context), IAlertsRepository
{
    public Task<Alerts?> FindAlertsByIdAsync(int id)
    {
        return Context.Set<Alerts>().FirstOrDefaultAsync(x=>x.Id == id);
    }
}

