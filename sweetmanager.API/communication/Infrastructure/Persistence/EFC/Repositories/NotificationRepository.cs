using Microsoft.EntityFrameworkCore;
using sweetmanager.API.communication.Domain.Model.Aggregates;
using sweetmanager.API.communication.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.communication.Infrastructure.Persistence.EFC.Repositories;

public class NotificationRepository(AppDbContext context) : BaseRepository<Notification>(context), INotificationRepository
{
    public Task<Notification?> FindNotificationByIdAsync(int id)
    {
        return Context.Set<Notification>().FirstOrDefaultAsync(x => x.Id == id);
    }
}