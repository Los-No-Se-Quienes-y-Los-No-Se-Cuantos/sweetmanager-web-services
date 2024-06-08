using sweetmanager.API.Communication.Domain.Model.Aggregates;
using sweetmanager.API.Communication.Domain.Model.Commands;

namespace sweetmanager.API.Communication.Domain.Services;

public interface INotificationCommandService
{
    Task<Notification?> Handle(CreateNotificationCommand command);
}