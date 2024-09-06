namespace sweetmanager.API.Communication.Domain.Model.Commands.Alerts;

public record SendAlertsCommand(int RoomId, int? UserId, string Description);