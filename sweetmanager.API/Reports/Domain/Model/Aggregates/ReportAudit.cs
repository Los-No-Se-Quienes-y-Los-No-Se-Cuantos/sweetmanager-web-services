using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace sweetmanager.API.Reports.Domain.Model.Aggregates;

public  partial class Report : IEntityWithCreatedUpdatedDate 
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("CreatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}
