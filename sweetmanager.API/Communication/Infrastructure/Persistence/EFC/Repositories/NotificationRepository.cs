using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Communication.Domain.Model.Aggregates;
using sweetmanager.API.Communication.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.Communication.Infrastructure.Persistence.EFC.Repositories;

public class NotificationRepository(AppDbContext context) : BaseRepository<Notification>(context), INotificationRepository
{
    public Task<Notification?> FindNotificationByIdAsync(int id)
    {
        return Context.Set<Notification>().FirstOrDefaultAsync(x => x.Id == id);
    }
}