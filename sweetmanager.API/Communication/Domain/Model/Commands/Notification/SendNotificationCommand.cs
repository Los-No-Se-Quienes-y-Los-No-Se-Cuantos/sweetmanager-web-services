namespace sweetmanager.API.Communication.Domain.Model.Commands;

public record SendNotificationCommand(int RoomId, int? UserId, string Message);