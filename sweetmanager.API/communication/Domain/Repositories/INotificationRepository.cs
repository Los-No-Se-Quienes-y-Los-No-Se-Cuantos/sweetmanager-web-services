using sweetmanager.API.communication.Domain.Model.Aggregates;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.communication.Domain.Repositories;

public interface INotificationRepository : IBaseRepository<Notification>
{
    Task<IEnumerable<Notification>> FindAllAsync();
    
    Task<Notification> CreateNotificationAsync(Notification newNotification);
}