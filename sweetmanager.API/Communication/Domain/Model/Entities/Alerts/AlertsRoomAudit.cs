using System.ComponentModel.DataAnnotations.Schema;

namespace sweetmanager.API.Communication.Domain.Model.Entities.Alerts;

public class AlertsRoomAudit
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}