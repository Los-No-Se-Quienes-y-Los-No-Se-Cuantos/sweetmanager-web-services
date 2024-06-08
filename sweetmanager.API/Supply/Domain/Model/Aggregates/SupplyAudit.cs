using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace sweetmanager.API.Supply.Domain.Model.Aggregates;

public partial class Supply : IEntityWithCreatedUpdatedDate
{
        [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }        
}
