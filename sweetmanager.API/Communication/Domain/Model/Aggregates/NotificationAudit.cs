using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace sweetmanager.API.Communication.Domain.Model.Aggregates;

public partial class Notification : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}