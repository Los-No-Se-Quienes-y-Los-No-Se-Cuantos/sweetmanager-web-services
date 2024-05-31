using sweetmanager.API.communication.Domain.Model.Aggregates;

namespace sweetmanager.API.communication.Domain.Model.Queries;

public record CreateNotificationQuery(Notification newNotificationSource);