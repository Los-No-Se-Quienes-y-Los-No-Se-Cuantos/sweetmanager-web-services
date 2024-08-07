using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace sweetmanager.API.IAM.Domain.Model.Entities;

public partial class Role : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    
    [Column("UpdatedAt")]  public DateTimeOffset? UpdatedDate { get; set; }
}