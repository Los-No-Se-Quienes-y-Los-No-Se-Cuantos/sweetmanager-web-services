using sweetmanager.API.communication.Domain.Model.Aggregates;
using sweetmanager.API.communication.Domain.Model.Commands;

namespace sweetmanager.API.communication.Domain.Services;

public interface INotificationCommandService
{
    Task<Notification?> Handle(CreateNotificationCommand command);
}