using Microsoft.EntityFrameworkCore;
using sweetmanager.API.communication.Domain.Model.Aggregates;
using sweetmanager.API.communication.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.communication.Infrastructure.Persistence.EFC.Repositories;

public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
{
    public NotificationRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Notification>> FindAllAsync()
    {
        return await Context.Set<Notification>().ToListAsync();
    }

    public async Task<Notification> CreateNotificationAsync(Notification newNotification)
    {
        await Context.Set<Notification>().AddAsync(newNotification);
        
        return newNotification;
    }
}