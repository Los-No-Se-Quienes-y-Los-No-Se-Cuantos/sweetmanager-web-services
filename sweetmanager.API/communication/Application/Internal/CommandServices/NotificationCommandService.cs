using sweetmanager.API.communication.Domain.Model.Aggregates;
using sweetmanager.API.communication.Domain.Model.Commands;
using sweetmanager.API.communication.Domain.Repositories;
using sweetmanager.API.communication.Domain.Services;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.communication.Application.Internal.CommandServices;

public class NotificationCommandService(INotificationRepository notificationRepository, IUnitOfWork unitOfWork) : INotificationCommandService
{
    public Task<Notification> Handle(CreateNotificationCommand command)
    {
        throw new NotImplementedException();
    }
}