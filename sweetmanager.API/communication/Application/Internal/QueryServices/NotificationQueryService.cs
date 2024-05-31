using sweetmanager.API.communication.Domain.Model.Aggregates;
using sweetmanager.API.communication.Domain.Model.Queries;
using sweetmanager.API.communication.Domain.Repositories;
using sweetmanager.API.communication.Domain.Services;

namespace sweetmanager.API.communication.Application.Internal.QueryServices;

public class NotificationQueryService(INotificationRepository notificationRepository) : INotificationQueryService
{
    public Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query)
    {
        throw new NotImplementedException();
    }
}