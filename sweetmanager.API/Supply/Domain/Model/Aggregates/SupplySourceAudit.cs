using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace sweetmanager.API.Supply.Domain.Model.Aggregates;

public partial class SupplySource : IEntityWithCreatedUpdatedDate
{
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }        
}
