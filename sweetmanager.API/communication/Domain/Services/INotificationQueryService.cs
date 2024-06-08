using sweetmanager.API.communication.Domain.Model.Aggregates;
using sweetmanager.API.communication.Domain.Model.Queries;

namespace sweetmanager.API.communication.Domain.Services;

public interface INotificationQueryService
{
    Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query);
    
    Task<Notification?> Handle(GetNotificationByIdQuery query);
    
}