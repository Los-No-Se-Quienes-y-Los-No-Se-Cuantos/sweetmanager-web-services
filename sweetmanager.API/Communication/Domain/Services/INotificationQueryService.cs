using sweetmanager.API.Communication.Domain.Model.Aggregates;
using sweetmanager.API.Communication.Domain.Model.Queries;

namespace sweetmanager.API.Communication.Domain.Services;

public interface INotificationQueryService
{
    Task<IEnumerable<Notification>> Handle(GetAllNotificationsQuery query);
    
    Task<Notification?> Handle(GetNotificationByIdQuery query);
    
}