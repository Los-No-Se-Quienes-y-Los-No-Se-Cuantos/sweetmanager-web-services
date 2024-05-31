using sweetmanager.API.interaction.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.interaction.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<IEnumerable<Notification>> FindAllAsync();
    
    Task<Notification> CreateNotificationAsync(Notification newNotification);
}